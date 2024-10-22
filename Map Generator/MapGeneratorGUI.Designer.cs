namespace Map_Generator
{
    partial class MapGeneratorGUI
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MapGeneratorGUI));
            MapPreviewPanel = new Panel();
            button1 = new Button();
            SuspendLayout();
            // 
            // MapPreviewPanel
            // 
            MapPreviewPanel.BackgroundImage = (Image)resources.GetObject("MapPreviewPanel.BackgroundImage");
            MapPreviewPanel.Location = new Point(496, 2);
            MapPreviewPanel.Name = "MapPreviewPanel";
            MapPreviewPanel.Size = new Size(512, 512);
            MapPreviewPanel.TabIndex = 0;
            // 
            // button1
            // 
            button1.Location = new Point(40, 58);
            button1.Name = "button1";
            button1.Size = new Size(178, 81);
            button1.TabIndex = 1;
            button1.Text = "button1";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // MapGeneratorGUI
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1010, 517);
            Controls.Add(button1);
            Controls.Add(MapPreviewPanel);
            Name = "MapGeneratorGUI";
            Text = "Project Blenordia: Map Generator";
            Load += MapGeneratorGUI_Load;
            ResumeLayout(false);
        }

        #endregion

        private Panel MapPreviewPanel;
        private Button button1;
    }
}
