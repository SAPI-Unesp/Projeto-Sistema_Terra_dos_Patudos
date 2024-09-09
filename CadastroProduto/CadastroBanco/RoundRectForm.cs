using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

public class RoundRectForm : Form
{

    [DllImport("dwmapi.dll", PreserveSig = false)]
    private static extern void DwmEnableBlurBehindWindow(IntPtr hWnd, ref DWM_BLURBEHIND pBlurBehind);

    [DllImport("dwmapi.dll", PreserveSig = false)]
    private static extern void DwmExtendFrameIntoClientArea(IntPtr hWnd, ref MARGINS pMargins);

    private struct DWM_BLURBEHIND
    {
        public uint dwFlags;
        public bool fEnable;
        public IntPtr hRegion;
        public uint dwReserved;
    }

    private struct MARGINS
    {
        public int left;
        public int right;
        public int top;
        public int bottom;
    }

    private bool isDragging = false;
    private Point lastCursor;
    private Point lastForm;

    private Rectangle closeButton;
    private Rectangle minimizeButton;

    private Pen borderPen;

    private const int buttonSize = 30;
    private const int iconSize = 30;
    private RoundedButton closeButton1;
    private RoundedTextBox roundedTextBox1;
    private RoundedTextBox roundedTextBox2;
    public RoundRectForm()
    {

        //this.Size = new Size(800, 600); // Defina o tamanho do formulário

        InitializeComponent();
        this.SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.OptimizedDoubleBuffer, true);
        this.FormBorderStyle = FormBorderStyle.None;
        this.BackColor = Color.White; // Define a cor de refundo
        this.Size = new Size(800, 600); // Defina um tamanho inicial

        this.MouseDown += new MouseEventHandler(RoundRectForm_MouseDown);
        this.MouseMove += new MouseEventHandler(RoundRectForm_MouseMove);
        this.MouseUp += new MouseEventHandler(RoundRectForm_MouseUp);
        this.Paint += new PaintEventHandler(RoundRectForm_Paint);
        this.Click += new EventHandler(RoundRectForm_Click);

        // Inicialize os retângulos dos botões
        closeButton = new Rectangle(this.ClientSize.Width - buttonSize - 10, 10, buttonSize, buttonSize);
        minimizeButton = new Rectangle(this.ClientSize.Width - buttonSize * 2 - 20, 10, buttonSize, buttonSize);

        // Inicialize o pincel da borda com uma largura maior
        borderPen = new Pen(Color.Black, 4); // A cor da borda é preta e a largura é 4 pixels
        
        InitializeTextBoxes(this.Controls);

    }
    private void InitializeComponent()
    {
            this.SuspendLayout();
            // 
            // RoundRectForm
            // 
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Name = "RoundRectForm";
            this.Load += new System.EventHandler(this.RoundRectForm_Load);
            this.ResumeLayout(false);

    }

    private void InitializeTextBoxes(Control.ControlCollection controls)
    {
        foreach (Control control in controls)
        {
            if (control is System.Windows.Forms.TextBox)
            {
                // Se for uma TextBox, aplica o estilo arredondado
                ApplyRoundedStyle((System.Windows.Forms.TextBox)control);
            }
            else if (control.HasChildren)
            {
                // Se o controle tem filhos, aplica o estilo recursivamente
                InitializeTextBoxes(control.Controls);
            }
        }
    }

    private void ApplyRoundedStyle(System.Windows.Forms.TextBox textBox)
    {
        textBox.BorderStyle = BorderStyle.None;
        textBox.BackColor = Color.White; // Define a cor de fundo da TextBox
        textBox.ForeColor = Color.Black; // Define a cor do texto

        // Cria um painel personalizado para desenhar a borda arredondada
        Panel roundedPanel = new Panel
        {
            Location = textBox.Location,
            Size = textBox.Size,
            BackColor = Color.Transparent,
            Padding = new Padding(2) // Adiciona padding para criar espaço para a borda
        };

        this.Controls.Add(roundedPanel); // Adiciona o painel ao formulário
        roundedPanel.BringToFront(); // Garante que o painel fique acima dos outros controles

        // Cria um evento de pintura para desenhar a borda arredondada
        roundedPanel.Paint += (sender, e) =>
        {
            using (GraphicsPath path = new GraphicsPath())
            {
                path.AddArc(0, 0, 20, 20, 180, 90);
                path.AddArc(roundedPanel.Width - 20 - 1, 0, 20, 20, 270, 90);
                path.AddArc(roundedPanel.Width - 20 - 1, roundedPanel.Height - 20 - 1, 20, 20, 0, 90);
                path.AddArc(0, roundedPanel.Height - 20 - 1, 20, 20, 90, 90);
                path.CloseFigure();

                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                e.Graphics.FillPath(new SolidBrush(Color.White), path); // Fundo do painel
                e.Graphics.DrawPath(new Pen(Color.Black, 3), path); // Borda do painel
            }
        };

        // Ajusta a localização da TextBox dentro do painel
        textBox.Location = new Point(roundedPanel.Padding.Left, roundedPanel.Padding.Top);
        textBox.Size = new Size(roundedPanel.Width - 2 * roundedPanel.Padding.Left, roundedPanel.Height - 2 * roundedPanel.Padding.Top);
        roundedPanel.Controls.Add(textBox); // Adiciona a TextBox ao painel
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        base.OnPaint(e);

        using (GraphicsPath path = new GraphicsPath())
        {
            path.AddArc(0, 0, 20, 20, 180, 90);
            path.AddArc(this.Width - 20, 0, 20, 20, 270, 90);
            path.AddArc(this.Width - 20, this.Height - 20, 20, 20, 0, 90);
            path.AddArc(0, this.Height - 20, 20, 20, 90, 90);
            path.CloseFigure();

            this.Region = new Region(path);
        }

        DrawControlButtons(e.Graphics);
        DrawBorder(e.Graphics);
    }

    private void DrawControlButtons(Graphics g)
    {
        // Desenha o botão de fechar
        using (Brush brush = new SolidBrush(Color.Transparent)) // Cor fixa para o botão de fechar
        {
            g.FillRectangle(brush, closeButton);
        }

        // Desenha o "X" para fechar
        using (Pen pen = new Pen(Color.Black, 3))
        {
            Point[] xPoints = new Point[]
            {
                new Point(closeButton.Left + 6, closeButton.Top + 6),
                new Point(closeButton.Right - 6, closeButton.Bottom - 6),
                new Point(closeButton.Left + 6, closeButton.Bottom - 6),
                new Point(closeButton.Right - 6, closeButton.Top + 6)
            };
            g.DrawLine(pen, xPoints[0], xPoints[1]);
            g.DrawLine(pen, xPoints[2], xPoints[3]);
        }

        // Desenha o botão de minimizar
        using (Brush brush = new SolidBrush(Color.Transparent)) // Cor fixa para o botão de minimizar
        {
            g.FillRectangle(brush, minimizeButton);
        }

        // Desenha o "-" para minimizar
        using (Pen pen = new Pen(Color.Black, 3))
        {
            g.DrawLine(pen, new Point(minimizeButton.Left + 6, minimizeButton.Top + minimizeButton.Height / 2),
                             new Point(minimizeButton.Right - 6, minimizeButton.Top + minimizeButton.Height / 2));
        }
    }

    private void DrawBorder(Graphics g)
    {
        using (GraphicsPath path = new GraphicsPath())
        {
            path.AddArc(0, 0, 20, 20, 180, 90);
            path.AddArc(this.Width - 20, 0, 20, 20, 270, 90);
            path.AddArc(this.Width - 20, this.Height - 20, 20, 20, 0, 90);
            path.AddArc(0, this.Height - 20, 20, 20, 90, 90);
            path.CloseFigure();

            g.DrawPath(borderPen, path);
        }
    }

    private void RoundRectForm_MouseDown(object sender, MouseEventArgs e)
    {
        if (e.Button == MouseButtons.Left)
        {
            if (closeButton.Contains(e.Location))
            {
                this.Close();
            }
            else if (minimizeButton.Contains(e.Location))
            {
                this.WindowState = FormWindowState.Minimized;
            }
            else
            {
                isDragging = true;
                lastCursor = e.Location;
                lastForm = this.Location;
            }
        }
    }

    private void RoundRectForm_MouseMove(object sender, MouseEventArgs e)
    {
        if (isDragging)
        {
            // Atualiza a posição da janela
            this.Location = new Point(
                this.Location.X + (e.X - lastCursor.X),
                this.Location.Y + (e.Y - lastCursor.Y)
            );
        }
    }

    private void RoundRectForm_MouseUp(object sender, MouseEventArgs e)
    {
        if (e.Button == MouseButtons.Left)
        {
            isDragging = false;
        }
    }

    private void RoundRectForm_Paint(object sender, PaintEventArgs e)
    {
        // Recalcule a posição dos botões após redimensionar
        closeButton = new Rectangle(this.ClientSize.Width - buttonSize - 10, 10, buttonSize, buttonSize);
        minimizeButton = new Rectangle(this.ClientSize.Width - buttonSize * 2 - 20, 10, buttonSize, buttonSize);
    }

    private void RoundRectForm_Click(object sender, EventArgs e)
    {
        // Atualize a posição dos botões no clique para se ajustar ao tamanho da janela
        Invalidate();
    }

    private void RoundRectForm_Load(object sender, EventArgs e)
    {

    }
}
