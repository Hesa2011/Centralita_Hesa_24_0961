// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");

//Desarrollar una solucion que aplique los 4 pilares de la Programacion Orientada a Objetos (Abstraccion, Encapsulamiento, Herencia y Polimorfismo). El enunciado esta colocado en adjunto.
using System;
using System.Collections.Generic;

public abstract class Llamada
{
    protected string numOrigen;
    protected string numDestino;
    protected int duracion;

    public Llamada(string numOrigen, string numDestino, int duracion)
    {
        this.numOrigen = numOrigen;
        this.numDestino = numDestino;
        this.duracion = duracion;
    }

    public abstract double CalcularCosto();
}

public class LlamadaLocal : Llamada
{
    private const double COSTO_POR_SEGUNDO = 0.15;

    public LlamadaLocal(string numOrigen, string numDestino, int duracion)
        : base(numOrigen, numDestino, duracion)
    {
    }

    public override double CalcularCosto()
    {
        return duracion * COSTO_POR_SEGUNDO;
    }

    public override string ToString()
    {
        return $"Llamada Local: {numOrigen} a {numDestino} de {duracion} segundos. Costo: {CalcularCosto()}€";
    }
}

public class LlamadaProvincial : Llamada
{
    private int franjaHoraria;
    private double costoPorSegundo;

    public LlamadaProvincial(string numOrigen, string numDestino, int duracion, int franjaHoraria)
        : base(numOrigen, numDestino, duracion)
    {
        this.franjaHoraria = franjaHoraria;
        switch (franjaHoraria)
        {
            case 1:
                costoPorSegundo = 0.20;
                break;
            case 2:
                costoPorSegundo = 0.25;
                break;
            case 3:
                costoPorSegundo = 0.30;
                break;
        }
    }

    public override double CalcularCosto()
    {
        return duracion * costoPorSegundo;
    }

    public override string ToString()
    {
        return $"Llamada Provincial: {numOrigen} a {numDestino} de {duracion} segundos en franja {franjaHoraria}. Costo: {CalcularCosto()}€";
    }
}

public class Centralita
{
    private int numeroLlamadas;
    private double costoTotal;
    private List<Llamada> llamadas;

    public Centralita()
    {
        numeroLlamadas = 0;
        costoTotal = 0;
        llamadas = new List<Llamada>();
    }

    public void RegistrarLlamada(Llamada llamada)
    {
        llamadas.Add(llamada);
        numeroLlamadas++;
        costoTotal += llamada.CalcularCosto();
    }

    public void MostrarLlamadas()
    {
        foreach (Llamada llamada in llamadas)
        {
            Console.WriteLine(llamada.ToString());
        }
        Console.WriteLine($"Número total de llamadas: {numeroLlamadas}");
        Console.WriteLine($"Costo total de todas las llamadas: {costoTotal}€");
    }
}

class Practica2
{
    static void Main(string[] args)
    {
        Centralita centralita = new Centralita();

        // Registro de llamadas
        centralita.RegistrarLlamada(new LlamadaLocal("123-456", "789-012", 60));
        centralita.RegistrarLlamada(new LlamadaProvincial("123-456", "789-012", 120, 1));
        centralita.RegistrarLlamada(new LlamadaProvincial("123-456", "789-012", 180, 2));
        centralita.RegistrarLlamada(new LlamadaProvincial("123-456", "789-012", 240, 3));

        // Mostrar todas las llamadas registradas
        centralita.MostrarLlamadas();
    }
}
