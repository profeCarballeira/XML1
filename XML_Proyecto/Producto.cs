﻿using System;

[Serializable]

public class Producto
{
    public string? Nombre { get; set; }

    public decimal Precio { get; set; }
    
    public int Cantidad { get; set; }
}
