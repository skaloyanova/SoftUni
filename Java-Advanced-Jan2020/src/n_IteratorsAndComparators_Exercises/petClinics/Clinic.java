package n_IteratorsAndComparators_Exercises.petClinics;

import java.util.Arrays;

public class Clinic {
    private String name;
    private Pet[] rooms;

    public Clinic(String name, int roomCount) {
        if (roomCount % 2 == 0) {
            throw new IllegalArgumentException("Rooms should be odd number");
        }
        this.name = name;
        this.rooms = new Pet[roomCount];
    }

    public boolean addPet(Pet pet) {
        int currentRoom = rooms.length / 2;
        for (int i = 0; i < rooms.length; i++) {

            if (i % 2 == 0) {
                currentRoom += i;
            } else {
                currentRoom -= i;
            }

            if (rooms[currentRoom] == null) {
                rooms[currentRoom] = pet;
                return true;
            }
        }
        return false;
    }

    public boolean releasePet() {
        int midRoom = rooms.length / 2;
        for (int i = midRoom; i < rooms.length; i++) {
            if (rooms[i] != null) {
                rooms[i] = null;
                return true;
            }
        }
        for (int i = 0; i < midRoom; i++) {
            if (rooms[i] != null) {
                rooms[i] = null;
                return true;
            }
        }
        //
//        int index = 0;
//        for (int i = 0; i < rooms.length; i++) {
//            index = midRoom + i;
//            if(index== rooms.length - 1) {
//                midRoom = -midRoom - 1;
//            }
//            if (rooms[i] != null) {
//                rooms[i] = null;
//                return true;
//            }
//        }
        return false;
    }

    public boolean HasEmptyRooms() {
        for (Pet room : rooms) {
            if (room == null) {
                return true;
            }
        }
        return false;
    }

    public void print() {
        for (Pet room : rooms) {
            if (room == null) {
                System.out.println("Room empty");
            } else {
                System.out.println(room);
            }
        }
    }

    public void print(int roomNum) {
        if (rooms[roomNum - 1] == null) {
            System.out.println("Room empty");
        } else {
            System.out.println(rooms[roomNum - 1]);
        }
    }

    @Override
    public String toString() {
        return name + ": " + Arrays.toString(rooms);
    }
}
