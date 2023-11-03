package h_interfacesAndAbstraction_Exercises.telephony;

import java.util.List;

public class Smartphone implements Callable, Browsable {

    private List<String> numbers;
    private List<String> urls;

    public Smartphone(List<String> numbers, List<String> urls) {
        this.numbers = numbers;
        this.urls = urls;
    }

    @Override
    public String call() {
        StringBuilder sb = new StringBuilder();

        for (String number : numbers) {
            try {
                if (Long.parseLong(number) >= 0) {
                    sb.append("Calling... ").append(number);
                } else {
                    sb.append("Invalid number!");
                }
            } catch (NumberFormatException e) {
                sb.append("Invalid number!");
            }
            sb.append(System.lineSeparator());
        }

        return sb.toString();
    }

    @Override
    public String browse() {
        StringBuilder sb = new StringBuilder();
        for (String url : urls) {
            boolean isValidUrl = true;
            for (int i = 0; i < url.length(); i++) {
                if (Character.isDigit(url.charAt(i))) {
                    isValidUrl = false;
                    break;
                }
            }
            if (isValidUrl) {
                sb.append(String.format("Browsing: %s!", url));
            } else {
                sb.append("Invalid URL!");
            }
            sb.append(System.lineSeparator());
        }
        return sb.toString();
    }
}
