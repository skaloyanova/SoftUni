package workshop_SmartArray_CustomStack;

import java.util.Arrays;

public class Main {
    public static void main(String[] args) {

        // SmartArray
//        SmartArray array = new SmartArray();
//        array.add(10);  // 0
//        array.add(20);  // 1
//        array.add(30);  // 2
//        array.add(35);  // 3
//        array.add(40);  // 4
//
//        System.out.println(array);
////        System.out.println("get i2 -> " + array.get(2));
////        System.out.println("get i3 -> " + array.get(3));
//
////        System.out.println(String.format("size before: %d || remove i4: %d || size after: %d",
////                array.size(), array.remove(4),array.size()));
////        System.out.println(array);
////        System.out.println(String.format("size before: %d || remove i2: %d || size after: %d",
////                array.size(), array.remove(2), array.size()));
////        System.out.println(array);
////        System.out.println(String.format("size before: %d || remove i0: %d || size after: %d",
////                array.size(), array.remove(0), array.size()));
////        System.out.println(array);
//        array.add(0, 5);
//        System.out.println(array);
//        array.add(5, 37);
//        System.out.println(array);
////        array.add(6, 45);
//        array.add(45);
//        array.add(7, 7);
//        System.out.println(array);
//        System.out.println(array.printInternalArray());

        //CustomStack
        CustomStack stack = new CustomStack();
        stack.push(10);
        System.out.println("added 1: " + stack.peek());
        stack.push(20);
        System.out.println("added 2: " + stack.peek());
        stack.push(30);
        System.out.println("added 3: " + stack.peek());
        System.out.println(stack);
        stack.printInternalStack();
        System.out.println();
        stack.push(40);
        stack.push(50);
        stack.printInternalStack();
        System.out.println();

        System.out.println(String.format("size before: %d || pop: %d || size after: %d",
                stack.size(), stack.pop(), stack.size()));
        System.out.println(String.format("size before: %d || pop: %d || size after: %d",
                stack.size(), stack.pop(), stack.size()));
        stack.printInternalStack();
        System.out.println(String.format("size before: %d || pop: %d || size after: %d",
                stack.size(), stack.pop(), stack.size()));
        System.out.println();
        System.out.println(stack);
        stack.printInternalStack();

    }
}
