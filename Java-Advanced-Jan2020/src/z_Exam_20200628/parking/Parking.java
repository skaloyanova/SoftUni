package z_Exam_20200628.parking;

import java.util.ArrayList;
import java.util.List;

public class Parking {
    private String type;
    private int capacity;
    List<Car> data;

    public Parking(String type, int capacity) {
        this.type = type;
        this.capacity = capacity;
        data = new ArrayList<>();
    }

    // adds an entity to the data if there is an empty cell for the car
    public void add(Car car) {
        if (data.size() < capacity) {
            data.add(car);
        }
    }

    // removes the car by given manufacturer and model, if such exists, and returns boolean
    public boolean remove(String manufacturer, String model) {
        Car car = getCar(manufacturer, model);
        if (car != null) {
            return data.remove(car);
        } else {
            return false;
        }
    }

    // returns the latest car (by year) or null if have no cars
    public Car getLatestCar() {
        if (data.size() == 0) {
            return null;
        }

        int latestYear = 0;
        Car latestCar = null;

        for (Car car : data) {
            if (car.getYear() > latestYear) {
                latestYear = car.getYear();
                latestCar = car;
            }
        }
        return latestCar;
    }

    // returns the car with the given manufacturer and model or null if there is no such car
    public Car getCar(String manufacturer, String model) {
        for (Car car : data) {
            if (car.getManufacturer().equals(manufacturer) && car.getModel().equals(model)) {
                return car;
            }
        }
        return null;
    }

    // returns the number of cars
    public int getCount() {
        return data.size();
    }

    // stats
    public String getStatistics() {
        StringBuilder output = new StringBuilder();
        output.append(String.format("The cars are parked in %s:", this.type));
        output.append(System.lineSeparator());
        for (Car car : data) {
            output.append(car).append(System.lineSeparator());
        }
        return output.toString();
    }
}
