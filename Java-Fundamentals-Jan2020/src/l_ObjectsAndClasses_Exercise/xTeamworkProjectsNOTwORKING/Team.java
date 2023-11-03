package l_ObjectsAndClasses_Exercise.xTeamworkProjectsNOTwORKING;

import java.util.List;

class Team {

    private String name;
    List<String> members;

    public int membersCount() {
        return members.size();
    }

    public Team(String name, List<String> members) {
        this.name = name;
        this.members = members;
    }

    public String getMember(int i) {
        return members.get(i);
    }

    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
    }
}