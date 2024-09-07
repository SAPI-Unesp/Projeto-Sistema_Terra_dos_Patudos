using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

public class RoundedTextBox : TextBox
{
    private int borderRadius = 5; // Raio das bordas arredondadas
    private int borderWidth = 3;    // Largura da borda
    private int paddingSize = 2;   // Tamanho do padding interno

    public RoundedTextBox()
    {
        this.BorderStyle = BorderStyle.None; // Remove a borda padrão
        this.SetStyle(ControlStyles.UserPaint, true);
        this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
        this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
        this.Padding = new Padding(paddingSize); // Adiciona espaço para a borda
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        using (GraphicsPath path = new GraphicsPath())
        {
            path.AddArc(0, 0, borderRadius, borderRadius, 180, 90);
            path.AddArc(this.Width - borderRadius - 1, 0, borderRadius, borderRadius, 270, 90);
            path.AddArc(this.Width - borderRadius - 1, this.Height - borderRadius - 1, borderRadius, borderRadius, 0, 90);
            path.AddArc(0, this.Height - borderRadius - 1, borderRadius, borderRadius, 90, 90);
            path.CloseFigure();

            this.Region = new Region(path);

            // Desenha o fundo da caixa de texto
            using (Brush brush = new SolidBrush(this.BackColor))
            {
                e.Graphics.FillPath(brush, path);
            }

            // Desenha a borda da caixa de texto
            using (Pen pen = new Pen(Color.Black, borderWidth))
            {
                e.Graphics.DrawPath(pen, path);
            }
        }

        // Ajusta a área onde o texto é desenhado
        Rectangle textRect = new Rectangle(paddingSize, paddingSize, this.ClientSize.Width - 2 * paddingSize, this.ClientSize.Height - 2 * paddingSize);
        TextRenderer.DrawText(e.Graphics, this.Text, this.Font, textRect, this.ForeColor, TextFormatFlags.Left | TextFormatFlags.VerticalCenter);
    }

    protected override void OnResize(EventArgs e)
    {
        base.OnResize(e);
        this.Invalidate(); // Força a caixa de texto a ser redesenhada quando redimensionada
    }
}
