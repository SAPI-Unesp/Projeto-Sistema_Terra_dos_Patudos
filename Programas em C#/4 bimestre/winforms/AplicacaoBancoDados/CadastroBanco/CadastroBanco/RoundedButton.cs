using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

public class RoundedButton : Button
{
    private int borderRadius = 20; // Raio das bordas arredondadas

    protected override void OnPaint(PaintEventArgs pevent)
    {
        base.OnPaint(pevent);

        // Cria o caminho gráfico com bordas arredondadas
        using (GraphicsPath path = new GraphicsPath())
        {
            path.AddArc(0, 0, borderRadius, borderRadius, 180, 90);
            path.AddArc(this.Width - borderRadius, 0, borderRadius, borderRadius, 270, 90);
            path.AddArc(this.Width - borderRadius, this.Height - borderRadius, borderRadius, borderRadius, 0, 90);
            path.AddArc(0, this.Height - borderRadius, borderRadius, borderRadius, 90, 90);
            path.CloseFigure();

            this.Region = new Region(path);

            // Desenha o botão com a cor de fundo
            using (Brush brush = new SolidBrush(this.BackColor))
            {
                pevent.Graphics.FillPath(brush, path);
            }

            // Desenha o texto do botão
            TextRenderer.DrawText(pevent.Graphics, this.Text, this.Font, this.ClientRectangle, this.ForeColor, TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
        }

        // Desenha a borda do botão
        using (GraphicsPath path = new GraphicsPath())
        {
            path.AddArc(0, 0, borderRadius, borderRadius, 180, 90);
            path.AddArc(this.Width - borderRadius, 0, borderRadius, borderRadius, 270, 90);
            path.AddArc(this.Width - borderRadius, this.Height - borderRadius, borderRadius, borderRadius, 0, 90);
            path.AddArc(0, this.Height - borderRadius, borderRadius, borderRadius, 90, 90);
            path.CloseFigure();

            using (Pen pen = new Pen(Color.Black, 2)) // Cor e largura da borda
            {
                pevent.Graphics.DrawPath(pen, path);
            }
        }
    }

    protected override void OnResize(EventArgs e)
    {
        base.OnResize(e);
        this.Invalidate(); // Força o botão a ser redesenhado quando redimensionado
    }
}
