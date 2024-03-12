namespace AspProj1.Models;
public class Laptops {
    public List<Laptop> allLaptops;

    public List<Laptop> selectedLaptops;

    public Laptops() {
        selectedLaptops = new List<Laptop>();
    }
    
    public  List<Laptop> getAllLaptops() {
        return allLaptops;
    }

    public  void setLaptops(List<Laptop> laptops) {
        this.allLaptops = laptops;
    }

    public void addLaptopToList(int index) {
        selectedLaptops.Add(allLaptops[index]);
    }

}