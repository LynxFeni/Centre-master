namespace WindowsFormsApp1
{
    partial class HistoryOverwrite
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label2 = new System.Windows.Forms.Label();
            this.txtBxCellNo = new System.Windows.Forms.TextBox();
            this.HistoryNotesGrid = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.HistoryNotesGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Open Sans", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(238, 166);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 15);
            this.label2.TabIndex = 15;
            this.label2.Text = "Cell No:";
            // 
            // txtBxCellNo
            // 
            this.txtBxCellNo.Location = new System.Drawing.Point(320, 166);
            this.txtBxCellNo.Margin = new System.Windows.Forms.Padding(2);
            this.txtBxCellNo.Name = "txtBxCellNo";
            this.txtBxCellNo.Size = new System.Drawing.Size(173, 20);
            this.txtBxCellNo.TabIndex = 14;
            // 
            // HistoryNotesGrid
            // 
            this.HistoryNotesGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.HistoryNotesGrid.Location = new System.Drawing.Point(171, 191);
            this.HistoryNotesGrid.Name = "HistoryNotesGrid";
            this.HistoryNotesGrid.Size = new System.Drawing.Size(405, 146);
            this.HistoryNotesGrid.TabIndex = 13;
            this.HistoryNotesGrid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.HistoryNotesGrid_CellContentClick);
            // 
            // HistoryOverwrite
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(918, 590);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtBxCellNo);
            this.Controls.Add(this.HistoryNotesGrid);
            this.Name = "HistoryOverwrite";
            this.Text = "HistoryOverwrite";
            this.Load += new System.EventHandler(this.HistoryOverwrite_Load);
            ((System.ComponentModel.ISupportInitialize)(this.HistoryNotesGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtBxCellNo;
        private System.Windows.Forms.DataGridView HistoryNotesGrid;
    }
}