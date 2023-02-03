using System;
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
            bool isValid = true; // valid unless proven otherwise

            if(inputBox.Text == "")// bad!
            {
                isValid = false;
                MessageBox.Show(inputBox.Tag.ToString() + " is required" );
                inputBox.Focus();
            }
            return isValid;
        }

        /// <summary>
        /// tests if text box has input in it (assumes that is has Tag property that states meaning)
        /// </summary>
        /// <param name="inputBox"> text box to validate </param>
        /// <returns>true is valid and false if not</returns>
        public static bool IsCommission(TextBox inputBox)
        {
            bool isValid = true; // valid unless proven otherwise

            if (inputBox.Text == "")// bad!
            {
                isValid = false;
                MessageBox.Show(inputBox.Tag.ToString() + " is required");
                inputBox.Focus();
            }
            return isValid;
        }

        /// <summary>
        /// tests if text box has input in it (assumes that is has Tag property that states meaning)
        /// </summary>
        /// <param name="inputBox"> text box to validate </param>
        /// <returns>true is valid and false if not</returns>
        public static bool IsDate(TextBox inputBox)
        {
            bool isValid = true; // valid unless proven otherwise

            if (inputBox.Text == "")// bad!
            {
                isValid = false;
                MessageBox.Show(inputBox.Tag.ToString() + " is required");
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
