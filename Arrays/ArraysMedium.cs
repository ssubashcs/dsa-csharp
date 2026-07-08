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

    internal static void Swap(ref int a, ref int b)
    {
        int temp = a;
        a = b;
        b = temp;
    }
}