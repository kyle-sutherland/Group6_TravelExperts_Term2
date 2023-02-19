using System;
using System.Globalization;
using System.Windows.Forms;

namespace TravelExpertsGUI
{
    /// <summary>
    /// a repository of validation methods
    /// </summary>
    public static class Validator
    {
        /// <summary>
        /// tests if text box has input in it (assumes that is has Tag property that states meaning)
        /// </summary>
        /// <param name="inputBox"> text box to validate </param>
        /// <returns>true is valid and false if not</returns>
        public static bool IsProvided(TextBox inputBox)
        {
            bool isValid = true;

            if(inputBox.Text == "")
            {
                isValid = false;
                MessageBox.Show(inputBox.Tag.ToString() + " is required" );
                inputBox.Focus();
            }
            return isValid;
        }

        /// <summary>
        /// tests if text box 
        /// </summary>
        /// <param name="inputBox1"> text box containing lesser number </param>
        /// <param name="inputBox2"> text box containing greater number </param>
        /// <returns>true is valid and false if not</returns>
        public static bool IsLessThanOrEqual(TextBox inputBox1, TextBox inputBox2)
        {
            bool isValid = true;
            

            decimal input1 = decimal.Parse(inputBox1.Text,
                NumberStyles.AllowCurrencySymbol |
                NumberStyles.AllowThousands |
                NumberStyles.AllowDecimalPoint);


            decimal input2 = decimal.Parse(inputBox2.Text,
                NumberStyles.AllowCurrencySymbol |
                NumberStyles.AllowThousands |
                NumberStyles.AllowDecimalPoint);

            //string box1 = inputBox1.Text.ToString();
            //decimal input1 = Convert.ToDecimal(box1);

            //string box2 = inputBox2.Text.ToString();
            //decimal input2 = Convert.ToDecimal(box2);

            //decimal input1 = Convert.ToDecimal(inputBox1.Text);
            //decimal input2 = Convert.ToDecimal(inputBox2.Text);

            if (input1 > input2)
            {
                isValid = false;
                MessageBox.Show(inputBox1.Tag.ToString() + " must be greater than " + inputBox2.Tag.ToString());
                inputBox1.Focus();
            }
            return isValid;
        }

        /// <summary>
        /// tests if one text box contains a valid date that is earlier than the valid date of another text box
        /// </summary>
        /// <param name="inputBox1"> text box with start date </param>
        /// <param name="inputBox2"> text box with end date </param>
        /// <returns>true is valid and false if not</returns>
        public static bool IsStartBeforeEndDate(TextBox inputBox1, TextBox inputBox2)
        {
            bool isValid = true; // valid unless proven otherwise
            DateTime startDate=Convert.ToDateTime(inputBox1.Text);
            DateTime endDate=Convert.ToDateTime(inputBox2.Text);

            if (startDate >= endDate)
            {
                isValid = false;
                MessageBox.Show(inputBox1.Tag.ToString() + " must be earlier than " + inputBox2.Tag.ToString());
                inputBox1.Focus();
            }
            return isValid;
        }

        /// <summary>
        /// tests if a text box contains a valid date
        /// </summary>
        /// <param name="inputBox1"> text box with date </param>
         /// <returns>true is valid and false if not</returns>
        public static bool IsValidDate(TextBox inputBox)
        {
            bool isValid = true;
            DateTime date;

            bool validDate = DateTime.TryParse(inputBox.Text, out date);

            //DateTime input = Convert.ToDateTime(inputBox.Text);
            //string DateText = Convert.ToString(input);

            //bool validDate = DateTime.TryParse(DateText, out date);

            if (!validDate)
            {
                isValid = false;
                MessageBox.Show(inputBox.Tag.ToString() + " must be a valid date of format yyyy-mm-dd");
                inputBox.Focus();
            }
            return isValid;
        }

        /// <summary>
        /// tests if text box has input in it (assumes that is has Tag property that states meaning)
        /// </summary>
        /// <param name="inputBox"> text box to validate </param>
        /// <returns>true is valid and false if not</returns>
        public static bool IsNotNull(TextBox inputBox)
        {
            bool isValid = true;

            if (inputBox.Text == "")
            {
                isValid = false;
                MessageBox.Show(inputBox.Tag.ToString() + " is required");
                inputBox.Focus();
            }
            return isValid;
        }

        /// <summary>
        /// tests if combo box has a value selected (assumes that is has Tag property that states meaning)
        /// </summary>
        /// <param name="comboBox"> combo box to validate </param>
        /// <returns>true is valid and false if not</returns>
        public static bool IsSelected(ComboBox comboBox)
        {
            bool isValid = true; // valid unless proven otherwise

            if (comboBox.SelectedIndex == -1)// no selection!
            {
                isValid = false;
                MessageBox.Show(comboBox.Tag.ToString() + " must be selected");
                comboBox.Focus();
            }
            return isValid;
        }

        /// <summary>
        ///  tests if text box contains non-negative int (assumes that is has Tag property that states meaning)
        /// </summary>
        /// <param name="inputBox">text box to validate</param>
        /// <returns>true is valid and false if not</returns>
        public static bool IsNonNegativeInt(TextBox inputBox)
        {
            bool isValid = true;
            int result; // result from parsing
            if (!Int32.TryParse(inputBox.Text, out result)) // if not an int
            {
                isValid = false;
                MessageBox.Show(inputBox.Tag.ToString() + " should be a whole number");
                // prepare for fixing
                inputBox.SelectAll(); // highlight the content
                inputBox.Focus();
            }
            else if(result < 0)// it is an int, but could be negative
            {
                isValid = false;
                MessageBox.Show(inputBox.Tag.ToString() + " has to be greater than or equal to zero");
                // prepare for fixing
                inputBox.SelectAll(); // highlight the content
                inputBox.Focus();
            }

            return isValid;
        }

        /// <summary>
        ///  tests if text box contains non-negative number (assumes that is has Tag property that states meaning)
        /// </summary>
        /// <param name="inputBox">text box to validate</param>
        /// <returns>true is valid and false if not</returns>
        public static bool IsNonNegativeDouble(TextBox inputBox)
        {
            bool isValid = true;
            double result; // result from parsing
            if (!Double.TryParse(inputBox.Text, out result)) // if not a number
            {
                isValid = false;
                MessageBox.Show(inputBox.Tag.ToString() + " should be a number");
                // prepare for fixing
                inputBox.SelectAll(); // highlight the content
                inputBox.Focus();
            }
            else if (result < 0)// it is a number, but could be negative
            {
                isValid = false;
                MessageBox.Show(inputBox.Tag.ToString() + " has to be greater than or equal to zero");
                // prepare for fixing
                inputBox.SelectAll(); // highlight the content
                inputBox.Focus();
            }

            return isValid;
        }

        /// <summary>
        ///  tests if text box contains non-negative number (assumes that is has Tag property that states meaning)
        /// </summary>
        /// <param name="inputBox">text box to validate</param>
        /// <returns>true is valid and false if not</returns>
        public static bool IsNonNegativeDecimal(TextBox inputBox)
        {
            bool isValid = true;
            decimal result; // result from parsing
            if (!Decimal.TryParse(inputBox.Text, out result)) // if not a number
            {
                isValid = false;
                MessageBox.Show(inputBox.Tag.ToString() + " should be a number");
                // prepare for fixing
                inputBox.SelectAll(); // highlight the content
                inputBox.Focus();
            }
            else if (result < 0)// it is a number, but could be negative
            {
                isValid = false;
                MessageBox.Show(inputBox.Tag.ToString() + " has to be greater than or equal to zero");
                // prepare for fixing
                inputBox.SelectAll(); // highlight the content
                inputBox.Focus();
            }

            return isValid;
        }

        /// <summary>
        ///  tests if text box contains valid percent (0-1 decimal) (assumes that is has Tag property that states meaning)
        /// </summary>
        /// <param name="inputBox">text box to validate</param>
        /// <returns>true is valid and false if not</returns>
        public static bool IsPercentDecimal(TextBox inputBox)
        {
            bool isValid = true;
            decimal result; // result from parsing
            if (!Decimal.TryParse(inputBox.Text, out result)) // if not a number
            {
                isValid = false;
                MessageBox.Show(inputBox.Tag.ToString() + " should be a decimal number 0 .. 1");
                // prepare for fixing
                inputBox.SelectAll(); // highlight the content
                inputBox.Focus();
            }
            else if (result < 0 || result > 1)// it is a number, but could be outside percent range
            {
                isValid = false;
                MessageBox.Show(inputBox.Tag.ToString() + " has to be between 0 and 1");
                // prepare for fixing
                inputBox.SelectAll(); // highlight the content
                inputBox.Focus();
            }

            return isValid;
        }

    } // class
}// namespace
