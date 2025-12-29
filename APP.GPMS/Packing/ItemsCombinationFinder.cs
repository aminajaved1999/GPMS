using System;
using System.IO;
using System.Windows.Forms;

namespace ItemsCombinationFinder
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        struct Item
        {
            public int quantity;
        }

        private void FindCombinations(int capacity, Item[] items, int numItems, StreamWriter outputFile)
        {
            int[] currentCombination = new int[numItems];
            int combinationId = 1;

            FindCombinationsUtil(capacity, items, currentCombination, 0, numItems, outputFile, ref combinationId);

            outputFile.Close();
        }

        private void FindCombinationsUtil(int capacity, Item[] items, int[] currentCombination, int currentItem, int numItems, StreamWriter outputFile, ref int combinationId)
        {
            if (currentItem == numItems)
            {
                int sum = 0;
                int countNonZero = 0;
                int indexOfNonZero = -1;

                for (int i = 0; i < numItems; ++i)
                {
                    sum += currentCombination[i];
                    if (currentCombination[i] > 0)
                    {
                        countNonZero++;
                        indexOfNonZero = i;
                    }
                }

                if (sum == capacity)
                {
                    outputFile.Write("Ratio_ID: " + combinationId + ", ");
                    for (int i = 0; i < numItems; ++i)
                    {
                        if (currentCombination[i] > 0)
                        {
                            outputFile.Write(" Item " + Convert.ToChar('A' + i) + ": " + currentCombination[i] + ", ");
                        }
                    }

                    if (countNonZero == 1)
                    {
                        outputFile.WriteLine(" Group: 1");
                    }
                    else if (countNonZero == 2)
                    {
                        outputFile.WriteLine(" Group: 2");
                    }
                    else if (countNonZero == 3)
                    {
                        outputFile.WriteLine(" Group: 3");
                    }
                    else if (countNonZero == 4)
                    {
                        outputFile.WriteLine(" Group: 4");
                    }
                    else
                    {
                        outputFile.WriteLine(" Group: X");
                    }

                    ++combinationId;
                }
                return;
            }

            for (int quantity = 0; quantity <= items[currentItem].quantity; ++quantity)
            {
                currentCombination[currentItem] = quantity;
                FindCombinationsUtil(capacity, items, currentCombination, currentItem + 1, numItems, outputFile, ref combinationId);
            }
        }

        private void btnFindCombinations_Click(object sender, EventArgs e)
        {
            int capacity, numItems;

            if (!int.TryParse(txtCapacity.Text, out capacity) || !int.TryParse(txtNumItems.Text, out numItems))
            {
                MessageBox.Show("Please enter valid numbers for capacity and number of items.");
                return;
            }

            Item[] items = new Item[numItems];
            for (int i = 0; i < numItems; ++i)
            {
                items[i].quantity = capacity;
            }

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Text File (*.txt)|*.txt";
            saveFileDialog.Title = "Save Combinations";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                StreamWriter outputFile = new StreamWriter(saveFileDialog.FileName);

                FindCombinations(capacity, items, numItems, outputFile);

                MessageBox.Show("Combinations saved to file successfully.");
            }
        }

    }
}
