using System;
public class ActividadClases
{
    public static void Main()
    {
        Estudiante estudiante = new Estudiante();
        try{
            Console.WriteLine("Ingrese el nombre del alumno:");
            estudiante.setNombre(Console.ReadLine());
            Console.WriteLine("Ingrese la edad del alumno:");
            estudiante.setEdad(Convert.ToInt32(Console.ReadLine()));
            Console.WriteLine("Ingrese la carrera del alumno:");
            estudiante.setCarrera(Console.ReadLine());
            Console.WriteLine("Ingrese el carnet del alumno:");
            estudiante.setCarnet(Convert.ToInt32(Console.ReadLine()));
            Console.WriteLine("Ingrese la nota de admisión del alumno:");
            estudiante.setNotaAdmision(Convert.ToDouble(Console.ReadLine()));
            estudiante.mostrarResumen();
            if(estudiante.puedeMatricular(estudiante.getCarnet(), estudiante.getNotaAdmision())){
                Console.WriteLine("El alumno si se puede matricular");
            } else {
                Console.WriteLine("El alumno no se puede matricular");
            }
        } catch {
            Console.WriteLine("Ingreso un dato en un formato no aceptado, intentelo de nuevo.");
        }
    }
}

public class Estudiante {
    private string nombre;
    private int edad;
    private string carrera;
    private int carnet;
    private double notaAdmision;
    public Estudiante() {
    }
    public Estudiante(string nombre, int edad, string carrera, int carnet, double notaAdmision) {
        this.nombre = nombre;
        this.edad = edad;
        this.carrera = carrera;
        this.carnet = carnet;
        this.notaAdmision = notaAdmision;
    }

    public string getNombre(){
        return nombre;
    }

    public void setNombre(string nombre){
        this.nombre = nombre;
    }

    public int getEdad(){
        return edad;
    }

    public void setEdad(int edad){
        this.edad = edad;
    }

    public string getCarrera(){
        return carrera;
    }

    public void setCarrera(string carrera){
        this.carrera = carrera;
    }

    public int getCarnet(){
        return carnet;
    }

    public void setCarnet(int carnet){
        this.carnet = carnet;
    }

    public double getNotaAdmision(){
        return notaAdmision;
    }

    public void setNotaAdmision(double notaAdmision){
        this.notaAdmision = notaAdmision;
    }
    public void mostrarResumen() {
        Console.WriteLine($"Nombre: {nombre}, edad: {edad}, carrera: {carrera}, carnet: {carnet}, nota de admisión: {notaAdmision}.");
    }

    public bool puedeMatricular(int carnet, double notaAdmision){
        string carnetString = Convert.ToString(carnet);
        if(notaAdmision >= 75 && carnetString.EndsWith("2025")){
            return true;
        } else {
            return false;
        }
    }
}