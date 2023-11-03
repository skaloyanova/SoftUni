package workshop_Deque;

public class Main {
    public static void main(String[] args) {
        CustomDeque stack = new CustomDeque();
//        stack.push(1);
//        stack.push(2);
//        stack.push(3);
//        stack.push(4);
//        stack.push(70);
//        System.out.println(stack);
//        System.out.println(stack.pop());
//        System.out.println(stack.pop());
//        System.out.println(stack.pop());
//        System.out.println(stack.pop());
//        System.out.println(stack);
//        System.out.println(stack.pop());
//        System.out.println(stack);
////        System.out.println(stack.pop());



        stack.offer(1);
        stack.offer(2);
        stack.offer(3);
        System.out.println(stack);
        stack.offer(4);
        System.out.println(stack);
        System.out.println(stack.poll());
        System.out.println(stack.poll());
        System.out.println(stack.poll());
        System.out.println(stack);
        System.out.println(stack.poll());
        System.out.println(stack);
        System.out.println(stack.poll());
    }
}
