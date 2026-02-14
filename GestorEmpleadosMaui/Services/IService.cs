using System;
using System.Collections.Generic;
using System.Text;

namespace GestorEmpleadosMaui.Services;

public interface IService<T>
{
    List<T> GetAll();
    T Get(int id);
    void Add(T item);
    void Delete(int id);
    void Update(T item);
}
