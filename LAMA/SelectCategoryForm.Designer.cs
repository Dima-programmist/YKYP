
namespace РасчетКУ
{
    partial class SelectCategoryForm
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
            this.treeViewCategory = new System.Windows.Forms.TreeView();
            this.btnChoiseCategory = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // treeViewCategory
            // 
            this.treeViewCategory.Dock = System.Windows.Forms.DockStyle.Left;
            this.treeViewCategory.Location = new System.Drawing.Point(0, 0);
            this.treeViewCategory.Name = "treeViewCategory";
            this.treeViewCategory.Size = new System.Drawing.Size(247, 324);
            this.treeViewCategory.TabIndex = 0;
            // 
            // btnChoiseCategory
            // 
            this.btnChoiseCategory.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnChoiseCategory.Location = new System.Drawing.Point(253, 137);
            this.btnChoiseCategory.Name = "btnChoiseCategory";
            this.btnChoiseCategory.Size = new System.Drawing.Size(86, 32);
            this.btnChoiseCategory.TabIndex = 1;
            this.btnChoiseCategory.Text = "Выбрать";
            this.btnChoiseCategory.UseVisualStyleBackColor = true;
            this.btnChoiseCategory.Click += new System.EventHandler(this.btnChoiseCategory_Click);
            // 
            // SelectCategoryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(238)))), ((int)(((byte)(168)))));
            this.ClientSize = new System.Drawing.Size(354, 324);
            this.Controls.Add(this.btnChoiseCategory);
            this.Controls.Add(this.treeViewCategory);
            this.Name = "SelectCategoryForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Выбор категории";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SelectCategoryForm_FormClosing);
            this.Load += new System.EventHandler(this.FormSelectCategory_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView treeViewCategory;
        private System.Windows.Forms.Button btnChoiseCategory;
    }
}