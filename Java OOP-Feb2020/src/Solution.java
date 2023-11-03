class Solution{

    public static void main(String[] args) {

        double p = Math.pow(2, 256);
        System.out.println(p);


        System.out.println(f(2, 2, 1));         //4
        System.out.println(f(2020, 2021, 1));   //4041
//        System.out.println(f(2020, 2021, 2));   //inf
//        System.out.println(f(2020, 2021, 3));   //inf
//        System.out.println(f(2020, 2021, 4));   //inf
//        System.out.println(f(2, 4, 4)); //inf


    }

    private static double f(double a, double b, double n) {

        if (n == 0) {
            return b + 1;
        }

        if (n == 1 && b == 0) {
            return a;
        }

        if (n == 2 && b == 0) {
            return 0;
        }

        if (n >= 3 && b == 0) {
            return 1;
        }

        return f(a, f(a, b - 1, n), n - 1);

    }

}