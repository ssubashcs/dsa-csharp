internal class ArraysMedium
{
    internal void Run()
    {
        LongestConsecutiveSequence([9,1,-3,2,4,8,3,-1,6,-2,-4,7]);
    }

    /// <summary>Better solution - Counting sort two pass approach for Leet 75. Sort Colors | 23rd June '26</summary>
    /// <remarks>Time: O(2n), Space: O(1)</remarks>
    private void CountingSort(int[] nums)
    {
        int zeros = 0, ones = 0, twos = 0;

        // counting the elements - O(n)
        foreach (int num in nums)
        {
            switch (num)
            {
                case 0:
                    zeros++;
                    break;
                case 1: 
                    ones++;
                    break;
                case 2: 
                    twos++;
                    break;
            }
        }

        int index = 0;

        // reconstruct the array in a sorted order - O(n)
        while (zeros-- > 0)
            nums[index++] = 0;

        while (ones-- > 0)
            nums[index++] = 1;

        while (twos-- > 0)
            nums[index++] = 2;
    }

    /// <summary>Optimal - Dutch National Flag Algorithm. | Leet 75. Sort Colors</summary>
    /// <remarks>Time: O(n), Space: O(1)</remarks>
    private void SortColors(int[] nums)
    {
        int n = nums.Length;

        int left = 0, mid = 0, right = n - 1;

        while (mid <= right)
        {
            switch (nums[mid])
            {
                case 0:
                    Swap(ref nums[mid], ref nums[left]);
                    left++; 
                    mid++;
                    break;

                case 1: 
                    mid++;
                    break;

                case 2:
                    Swap(ref nums[mid], ref nums[right]);
                    right--;
                    break;
            }
        }
    }

    /// <summary>128. Longest Consecutive Sequence - Better Native (Sorting approach)</summary>
    /// <remarks>T: O(n log n) | Space: O(1) extra space (Sorts the input array in place).</remarks>
    private int LongestConsecutiveSequence(int[] nums)
    {
        int n = nums.Length;

        if (n == 0) return 0;

        // O(n log n)
        Array.Sort(nums);

        int maxLength = 1, length = 1;

        // O(n)
        for (int i = 1; i < n; i++)
        {
            if (nums[i] == nums[i - 1]) continue;

            if (nums[i] == nums[i - 1] + 1)
            {
                length++;
            }
            else 
                length = 1;

            maxLength = Math.Max(length, maxLength);
        }

        return maxLength;
    }

    /// <summary>Leaders in an Array - Brute force</summary>
    /// <remarks>T: O(n²), S: O(n) used to return the answer.</remarks>
    public List<int> Leaders(List<int> nums) 
    {
        int n = nums.Count;

        // S: O(n)
        List<int> result = new List<int>();
        
        // T: O(n²)
        for (int i = 0; i < n; i++)
        {
            bool isLeader = true;

            for (int j = i; j < n; j++)
            {
                if (nums[j] > nums[i]) 
                {
                    isLeader = false;
                    break;
                }
            }

            if (isLeader) result.Add(nums[i]);
        }

        return result;
    }

    /// <summary>Leaders in an Array - Optimal</summary>
    /// <remarks>T: O(2n), S: O(n) used to return the answer.</remarks>
    public List<int> Leaders_Optimal(List<int> nums) 
    {
        int n = nums.Count;

        // S: O(n)
        List<int> result = new List<int>();
        
        int maxValue = int.MinValue;

        // T: O(n)
        for (int i = n - 1; i >= 0; i--)
        {
            if (nums[i] > maxValue)
            {
                result.Add(nums[i]); 
                maxValue = nums[i];
            }
        }

        // T: O(n / 2)
        result.Reverse();

        return result;
    }

    /// <summary>Optimal | T: O(2mn), S: O(1) - In-place marker approach</summary>
    // [[1, 1, 1], [0, 1, 1], [1, 0, 1]]
    public void SetMatrixZeroes(int[][] matrix) 
    {
        int rows = matrix.Length, cols = matrix[0].Length;

        // bool[] isRowZero = new bool[rows]; -> matrix[..][0] first column
        // bool[] isColZero = new bool[cols]; -> matrix[0][..] first row

        int colZero = 1;

        // Step 1: mark in the first row and first columns that need to be zeroed
        // T: O(m x n)
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                if (matrix[i][j] == 0)
                {
                    matrix[i][0] = 0;
                    
                    if (j == 0)
                        colZero = 0;
                    else
                        matrix[0][j] = 0;
                }
            }
        }

        // Step 2: update the remaining portion based on the markers - O(m x n) appx.
        for (int i = 1; i < rows; i++)
        {
            for (int j = 1; j < cols; j++)
            {
                if (matrix[i][j] != 0)
                {
                    if (matrix[0][j] == 0 || matrix[i][0] == 0)
                    {
                        matrix[i][j] = 0;
                    }
                }
            }
        }
 
        // Step 3: update the first row - O(n)
        if (matrix[0][0] == 0)
        {
            for (int i = 1; i < cols; i++)
            {
                matrix[0][i] = 0;
            }
        }

        // Step 4: update the first column - O(m)
        if (colZero == 0)
        {
            for (int j = 0; j < rows; j++)
            {
                matrix[j][0] = 0;
            }
        }
    }

    /// <summary>Brute Force | Time and Space: O(n²)</summary>
    // [[1,2,3],[4,5,6],[7,8,9]]
    private void RotateImage(int[][] matrix)
    {
        int n = matrix.Length;

        // S: O(n x n)
        int[][] jaggedArray = new int[n][];

        // O(n)
        for (int i = 0; i < n; i++)
        {
            jaggedArray[i] = new int[n];
        }

        // O(n x n)
        for (int i = 0; i < n; i++)
        {
            int col = n - 1 - i;

            for (int j = 0; j < n; j++)
            {
                jaggedArray[j][col] = matrix[i][j];
            }
        }

        // O(n x n)
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                matrix[i][j] = jaggedArray[i][j];
            }
        }
    }

    internal static void Swap(ref int a, ref int b)
    {
        int temp = a;
        a = b;
        b = temp;
    }
}