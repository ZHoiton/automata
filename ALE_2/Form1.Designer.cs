namespace ALE_2
{
    partial class Form1
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
            this.btn_open_file = new System.Windows.Forms.Button();
            this.btn_transform_from_dfa = new System.Windows.Forms.Button();
            this.txt_regex = new System.Windows.Forms.TextBox();
            this.btn_read_regex = new System.Windows.Forms.Button();
            this.list_test_vectors_from_file = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.list_test_vectors_from_program = new System.Windows.Forms.ListBox();
            this.button1 = new System.Windows.Forms.Button();
            this.list_number_of_words = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label_number_of_words = new System.Windows.Forms.Label();
            this.label_is_dfa = new System.Windows.Forms.Label();
            this.list_regex_words = new System.Windows.Forms.ListBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label_number_of_words_regex = new System.Windows.Forms.Label();
            this.txt_test_word = new System.Windows.Forms.TextBox();
            this.btn_test_word = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label_test_word_result = new System.Windows.Forms.Label();
            this.btn_transform_to_dfa_regex = new System.Windows.Forms.Button();
            this.label__regex_result = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.txt_regex_test_word = new System.Windows.Forms.TextBox();
            this.btn_test_word_regex = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_open_file
            // 
            this.btn_open_file.Location = new System.Drawing.Point(14, 12);
            this.btn_open_file.Name = "btn_open_file";
            this.btn_open_file.Size = new System.Drawing.Size(75, 23);
            this.btn_open_file.TabIndex = 0;
            this.btn_open_file.Text = "open file";
            this.btn_open_file.UseVisualStyleBackColor = true;
            this.btn_open_file.Click += new System.EventHandler(this.btn_open_file_Click);
            // 
            // btn_transform_from_dfa
            // 
            this.btn_transform_from_dfa.Location = new System.Drawing.Point(95, 12);
            this.btn_transform_from_dfa.Name = "btn_transform_from_dfa";
            this.btn_transform_from_dfa.Size = new System.Drawing.Size(144, 23);
            this.btn_transform_from_dfa.TabIndex = 3;
            this.btn_transform_from_dfa.Text = "transform to dfa";
            this.btn_transform_from_dfa.UseVisualStyleBackColor = true;
            this.btn_transform_from_dfa.Click += new System.EventHandler(this.btn_transform_from_dfa_Click);
            // 
            // txt_regex
            // 
            this.txt_regex.Location = new System.Drawing.Point(624, 12);
            this.txt_regex.Name = "txt_regex";
            this.txt_regex.Size = new System.Drawing.Size(230, 20);
            this.txt_regex.TabIndex = 4;
            // 
            // btn_read_regex
            // 
            this.btn_read_regex.Location = new System.Drawing.Point(860, 9);
            this.btn_read_regex.Name = "btn_read_regex";
            this.btn_read_regex.Size = new System.Drawing.Size(144, 23);
            this.btn_read_regex.TabIndex = 5;
            this.btn_read_regex.Text = "read regex";
            this.btn_read_regex.UseVisualStyleBackColor = true;
            this.btn_read_regex.Click += new System.EventHandler(this.btn_read_regex_Click);
            // 
            // list_test_vectors_from_file
            // 
            this.list_test_vectors_from_file.FormattingEnabled = true;
            this.list_test_vectors_from_file.Location = new System.Drawing.Point(19, 102);
            this.list_test_vectors_from_file.Name = "list_test_vectors_from_file";
            this.list_test_vectors_from_file.Size = new System.Drawing.Size(278, 342);
            this.list_test_vectors_from_file.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 83);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Test vectors from file";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(303, 83);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(130, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Test vectors from program";
            // 
            // list_test_vectors_from_program
            // 
            this.list_test_vectors_from_program.FormattingEnabled = true;
            this.list_test_vectors_from_program.Location = new System.Drawing.Point(303, 102);
            this.list_test_vectors_from_program.Name = "list_test_vectors_from_program";
            this.list_test_vectors_from_program.Size = new System.Drawing.Size(260, 342);
            this.list_test_vectors_from_program.TabIndex = 8;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(488, 450);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 37);
            this.button1.TabIndex = 10;
            this.button1.Text = "generate words";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // list_number_of_words
            // 
            this.list_number_of_words.FormattingEnabled = true;
            this.list_number_of_words.Location = new System.Drawing.Point(19, 493);
            this.list_number_of_words.Name = "list_number_of_words";
            this.list_number_of_words.Size = new System.Drawing.Size(544, 186);
            this.list_number_of_words.TabIndex = 11;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 474);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "words:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(148, 474);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(88, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "number of words:";
            // 
            // label_number_of_words
            // 
            this.label_number_of_words.AutoSize = true;
            this.label_number_of_words.Location = new System.Drawing.Point(233, 474);
            this.label_number_of_words.Name = "label_number_of_words";
            this.label_number_of_words.Size = new System.Drawing.Size(13, 13);
            this.label_number_of_words.TabIndex = 14;
            this.label_number_of_words.Text = "0";
            // 
            // label_is_dfa
            // 
            this.label_is_dfa.AutoSize = true;
            this.label_is_dfa.Location = new System.Drawing.Point(621, 138);
            this.label_is_dfa.Name = "label_is_dfa";
            this.label_is_dfa.Size = new System.Drawing.Size(0, 13);
            this.label_is_dfa.TabIndex = 16;
            // 
            // list_regex_words
            // 
            this.list_regex_words.FormattingEnabled = true;
            this.list_regex_words.Location = new System.Drawing.Point(624, 63);
            this.list_regex_words.Name = "list_regex_words";
            this.list_regex_words.Size = new System.Drawing.Size(230, 407);
            this.list_regex_words.TabIndex = 17;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(624, 47);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(72, 13);
            this.label6.TabIndex = 18;
            this.label6.Text = "Regex words:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(755, 473);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(88, 13);
            this.label7.TabIndex = 19;
            this.label7.Text = "number of words:";
            // 
            // label_number_of_words_regex
            // 
            this.label_number_of_words_regex.AutoSize = true;
            this.label_number_of_words_regex.Location = new System.Drawing.Point(849, 473);
            this.label_number_of_words_regex.Name = "label_number_of_words_regex";
            this.label_number_of_words_regex.Size = new System.Drawing.Size(0, 13);
            this.label_number_of_words_regex.TabIndex = 20;
            // 
            // txt_test_word
            // 
            this.txt_test_word.Location = new System.Drawing.Point(270, 12);
            this.txt_test_word.Name = "txt_test_word";
            this.txt_test_word.Size = new System.Drawing.Size(163, 20);
            this.txt_test_word.TabIndex = 21;
            // 
            // btn_test_word
            // 
            this.btn_test_word.Location = new System.Drawing.Point(439, 12);
            this.btn_test_word.Name = "btn_test_word";
            this.btn_test_word.Size = new System.Drawing.Size(75, 23);
            this.btn_test_word.TabIndex = 22;
            this.btn_test_word.Text = "test word";
            this.btn_test_word.UseVisualStyleBackColor = true;
            this.btn_test_word.Click += new System.EventHandler(this.btn_test_word_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(267, 35);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(71, 13);
            this.label5.TabIndex = 23;
            this.label5.Text = "is accepted?:";
            // 
            // label_test_word_result
            // 
            this.label_test_word_result.AutoSize = true;
            this.label_test_word_result.Location = new System.Drawing.Point(336, 35);
            this.label_test_word_result.Name = "label_test_word_result";
            this.label_test_word_result.Size = new System.Drawing.Size(0, 13);
            this.label_test_word_result.TabIndex = 24;
            // 
            // btn_transform_to_dfa_regex
            // 
            this.btn_transform_to_dfa_regex.Location = new System.Drawing.Point(860, 38);
            this.btn_transform_to_dfa_regex.Name = "btn_transform_to_dfa_regex";
            this.btn_transform_to_dfa_regex.Size = new System.Drawing.Size(144, 23);
            this.btn_transform_to_dfa_regex.TabIndex = 25;
            this.btn_transform_to_dfa_regex.Text = "transform to dfa";
            this.btn_transform_to_dfa_regex.UseVisualStyleBackColor = true;
            this.btn_transform_to_dfa_regex.Click += new System.EventHandler(this.btn_transform_to_dfa_regex_Click);
            // 
            // label__regex_result
            // 
            this.label__regex_result.AutoSize = true;
            this.label__regex_result.Location = new System.Drawing.Point(926, 154);
            this.label__regex_result.Name = "label__regex_result";
            this.label__regex_result.Size = new System.Drawing.Size(0, 13);
            this.label__regex_result.TabIndex = 29;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(857, 154);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(71, 13);
            this.label9.TabIndex = 28;
            this.label9.Text = "is accepted?:";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(1029, 67);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 27;
            this.button3.Text = "test word";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // txt_regex_test_word
            // 
            this.txt_regex_test_word.Location = new System.Drawing.Point(860, 131);
            this.txt_regex_test_word.Name = "txt_regex_test_word";
            this.txt_regex_test_word.Size = new System.Drawing.Size(144, 20);
            this.txt_regex_test_word.TabIndex = 26;
            // 
            // btn_test_word_regex
            // 
            this.btn_test_word_regex.Location = new System.Drawing.Point(860, 170);
            this.btn_test_word_regex.Name = "btn_test_word_regex";
            this.btn_test_word_regex.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btn_test_word_regex.Size = new System.Drawing.Size(144, 23);
            this.btn_test_word_regex.TabIndex = 30;
            this.btn_test_word_regex.Text = "test word";
            this.btn_test_word_regex.UseVisualStyleBackColor = true;
            this.btn_test_word_regex.Click += new System.EventHandler(this.btn_test_word_regex_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1021, 685);
            this.Controls.Add(this.btn_test_word_regex);
            this.Controls.Add(this.label__regex_result);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.txt_regex_test_word);
            this.Controls.Add(this.btn_transform_to_dfa_regex);
            this.Controls.Add(this.label_test_word_result);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btn_test_word);
            this.Controls.Add(this.txt_test_word);
            this.Controls.Add(this.label_number_of_words_regex);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.list_regex_words);
            this.Controls.Add(this.label_is_dfa);
            this.Controls.Add(this.label_number_of_words);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.list_number_of_words);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.list_test_vectors_from_program);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.list_test_vectors_from_file);
            this.Controls.Add(this.btn_read_regex);
            this.Controls.Add(this.txt_regex);
            this.Controls.Add(this.btn_transform_from_dfa);
            this.Controls.Add(this.btn_open_file);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_open_file;
        private System.Windows.Forms.Button btn_transform_from_dfa;
        private System.Windows.Forms.TextBox txt_regex;
        private System.Windows.Forms.Button btn_read_regex;
        private System.Windows.Forms.ListBox list_test_vectors_from_file;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox list_test_vectors_from_program;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ListBox list_number_of_words;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label_number_of_words;
        private System.Windows.Forms.Label label_is_dfa;
        private System.Windows.Forms.ListBox list_regex_words;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label_number_of_words_regex;
        private System.Windows.Forms.TextBox txt_test_word;
        private System.Windows.Forms.Button btn_test_word;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label_test_word_result;
        private System.Windows.Forms.Button btn_transform_to_dfa_regex;
        private System.Windows.Forms.Label label__regex_result;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox txt_regex_test_word;
        private System.Windows.Forms.Button btn_test_word_regex;

    }
}

