using System;

namespace builder
{
  internal class Program
  {
    static void Main(string[] args)
    {
      CarBuilder builder = new CarBuilder();

      Director director = new Director(builder);

      director.BuildSportsCar();

      Car car = builder.GetResult();

      Console.WriteLine("Автомобиль:");
      Console.WriteLine("Марка: " + car.Brand);
      Console.WriteLine("Модель: " + car.Model);
      Console.WriteLine("Максимальная скорость: " + car.MaxSpeed + " км/ч");
    }
  }

  public class Car
  {
    public string Brand;
    public string Model;
    public int MaxSpeed;
  }

  public interface IBuilder
  {
    void BuildBrand();
    void BuildModel();
    void BuildMaxSpeed();
  }

  public class CarBuilder : IBuilder
  {
    private Car car = new Car();

    public void BuildBrand()
    {
      car.Brand = "Porsche";
    }

    public void BuildModel()
    {
      car.Model = "911 Turbo";
    }

    public void BuildMaxSpeed()
    {
      car.MaxSpeed = 320;
    }

    public Car GetResult()
    {
      return car;
    }
  }

  public class Director
  {
    private IBuilder builder;

    public Director(IBuilder builder)
    {
      this.builder = builder;
    }

    public void BuildSportsCar()
    {
      builder.BuildBrand();
      builder.BuildModel();
      builder.BuildMaxSpeed();
    }
  }
}