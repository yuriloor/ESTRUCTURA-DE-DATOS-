
// Clase Circulo representa un círculo geométrico con un radio public class Circulo
{
private double radio; // Almacena el valor del radio del círculo

// Constructor que recibe el radio como argumento public Circulo(double radio)
{
this.radio = radio;
}

// CalcularArea devuelve el área del círculo usando la fórmula pi * radio^2 public double CalcularArea()
{
return Math.PI * radio * radio;
}

// CalcularPerimetro devuelve el perímetro del círculo usando la fórmula 2 * pi * radio
public double CalcularPerimetro()
{
return 2 * Math.PI * radio;
}
}

// Clase Rectangulo representa un rectángulo con base y altura public class Rectangulo
{
private double baseRect;	// Base del rectángulo private double altura;	// Altura del rectángulo

// Constructor que recibe la base y la altura como argumentos public Rectangulo(double baseRect, double altura)
{
this.baseRect = baseRect; this.altura = altura;
}

// CalcularArea devuelve el área del rectángulo (base * altura) public double CalcularArea()
{
return baseRect * altura;
}

// CalcularPerimetro devuelve el perímetro del rectángulo (2 * (base + altura)) public double CalcularPerimetro()

{
return 2 * (baseRect + altura);
}
}