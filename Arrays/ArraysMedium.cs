internal class ArraysMedium
{
    internal void Run()
    {
        LongestConsecutiveSequence([9,1,-3,2,4,8,3,-1,6,-2,-4,7]);
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
}