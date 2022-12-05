namespace Top_100_Liked_Questions
{
    internal class Program
    {
        static void Main()
        {

        }
        //20. Valid Parentheses
        public bool IsValid(string s)
        {

        }

        //1. Two Sum
        public int[] TwoSum(int[] nums, int target)
        {
            for (int i = 0; i < nums.Length - 1; i++)
            {
                for (int j = i + 1; j < nums.Length; j++)
                {
                    if (nums[i] + nums[j] == target)
                    {
                        return new int[] { i, j };
                    }
                }
            }
            return new int[2];
        }
    }
}