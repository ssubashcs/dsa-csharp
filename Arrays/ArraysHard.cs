internal class ArraysHard
{
    internal void Run()
    {
        PascalsTriangle_Optimal(5);
    }

    /// <summary>Pascal's Triangle | Brute - Time: O(n² x r) -> O(n³), Space: O(n²) | 16th July</summary>
    public IList<IList<int>> PascalsTriangle(int numRows) 
    {
        // O(n²)
        IList<IList<int>> result = new List<IList<int>>(numRows);

        // O(n²)
        for (int i = 1; i <= numRows; i++)
        {
            List<int> row = new(i);

            for (int j = 1; j <= i; j++)
            {
                row.Add(CalculateCombination(i - 1, j - 1));
            }

            result.Add(row);
        }

        int CalculateCombination(int n, int r)
        {
            int value = 1;

            // O(r)
            for (int i = 0; i < r; i++)
            {
                value *= n - i;

                // Dividing by a larger number (r - i) earlier can cause truncation before later multiplications have a chance to restore the value.
                value /= i + 1;
            }

            return value;
        }

        return result;
    }

    /// <summary>Pascal's Triangle | Optimal - Time: O(n²), Space: O(n²) to return the output | 17th July</summary>
    /// <remarks>Uses the binomial coefficient recurrence. This implementation uses 1-based row/position, 
    /// while the recurrence is defined using 0-based indices.</remarks>
    public IList<IList<int>> PascalsTriangle_Optimal(int numRows) 
    {
        // O(n²)
        IList<IList<int>> result = new List<IList<int>>(numRows);

        // Optimal - O(n²)
        // You can't asymptotically do better because Pascal's Triangle contains roughly n(n + 1) / 2 elements.
        for (int row = 1; row <= numRows; row++)
        {
            result.Add(GenerateRow(row));
        }

        return result;
        
        List<int> GenerateRow(int row)
        {
            List<int> pascalRow = new(row);

            int value = 1;

            pascalRow.Add(value);

            for (int pos = 2; pos <= row; pos++)
            {
                // pos is 1-based, so use (pos - 1) for the formula
                value = value * (row - pos + 1) / (pos - 1);

                pascalRow.Add(value);
            }

            return pascalRow;
        }
    }
}