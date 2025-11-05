public class NumArray {
    private int[] nums;

    public NumArray(int[] nums) {
        this.nums = nums;
    }
    
    public int SumRange(int left, int right) {
        return nums[left..(right + 1)].Sum();
    }
}
