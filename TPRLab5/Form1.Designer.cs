namespace TPRLab5
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.nuAlternatives = new System.Windows.Forms.NumericUpDown();
            this.nuCriteries = new System.Windows.Forms.NumericUpDown();
            this.dgvInput = new System.Windows.Forms.DataGridView();
            this.Name1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvCrits = new System.Windows.Forms.DataGridView();
            this.btnStart = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dgvEndResult = new System.Windows.Forms.DataGridView();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnLoad = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.nuAlternatives)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nuCriteries)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInput)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCrits)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEndResult)).BeginInit();
            this.SuspendLayout();
            // 
            // nuAlternatives
            // 
            this.nuAlternatives.Location = new System.Drawing.Point(23, 49);
            this.nuAlternatives.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nuAlternatives.Name = "nuAlternatives";
            this.nuAlternatives.Size = new System.Drawing.Size(133, 20);
            this.nuAlternatives.TabIndex = 0;
            this.nuAlternatives.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nuAlternatives.ValueChanged += new System.EventHandler(this.nuAlternatives_ValueChanged);
            // 
            // nuCriteries
            // 
            this.nuCriteries.Location = new System.Drawing.Point(187, 49);
            this.nuCriteries.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nuCriteries.Name = "nuCriteries";
            this.nuCriteries.Size = new System.Drawing.Size(162, 20);
            this.nuCriteries.TabIndex = 1;
            this.nuCriteries.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nuCriteries.ValueChanged += new System.EventHandler(this.nuCriteries_ValueChanged);
            // 
            // dgvInput
            // 
            this.dgvInput.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInput.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Name1});
            this.dgvInput.Location = new System.Drawing.Point(23, 103);
            this.dgvInput.Name = "dgvInput";
            this.dgvInput.Size = new System.Drawing.Size(363, 243);
            this.dgvInput.TabIndex = 2;
            this.dgvInput.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvInput_CellValueChanged);
            // 
            // Name1
            // 
            this.Name1.HeaderText = "Название";
            this.Name1.Name = "Name1";
            // 
            // dgvCrits
            // 
            this.dgvCrits.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCrits.Location = new System.Drawing.Point(430, 103);
            this.dgvCrits.Name = "dgvCrits";
            this.dgvCrits.Size = new System.Drawing.Size(350, 84);
            this.dgvCrits.TabIndex = 3;
            this.dgvCrits.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCrits_CellValueChanged);
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(430, 193);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(151, 27);
            this.btnStart.TabIndex = 4;
            this.btnStart.Text = "Расчёт";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(427, 76);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Веса критериев";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(184, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Кол-во критериев";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(108, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Кол-во альтернатив";
            // 
            // dgvEndResult
            // 
            this.dgvEndResult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEndResult.Location = new System.Drawing.Point(430, 235);
            this.dgvEndResult.Name = "dgvEndResult";
            this.dgvEndResult.Size = new System.Drawing.Size(349, 111);
            this.dgvEndResult.TabIndex = 8;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(427, 16);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 9;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(573, 16);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(73, 23);
            this.btnLoad.TabIndex = 10;
            this.btnLoad.Text = "Load";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(809, 450);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.dgvEndResult);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.dgvCrits);
            this.Controls.Add(this.dgvInput);
            this.Controls.Add(this.nuCriteries);
            this.Controls.Add(this.nuAlternatives);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nuAlternatives)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nuCriteries)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInput)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCrits)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEndResult)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown nuAlternatives;
        private System.Windows.Forms.NumericUpDown nuCriteries;
        private System.Windows.Forms.DataGridView dgvInput;
        private System.Windows.Forms.DataGridView dgvCrits;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.DataGridViewTextBoxColumn Name1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dgvEndResult;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnLoad;
    }
}

