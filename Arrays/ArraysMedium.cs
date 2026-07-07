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

    internal static void Swap(ref int a, ref int b)
    {
        int temp = a;
        a = b;
        b = temp;
    }
}