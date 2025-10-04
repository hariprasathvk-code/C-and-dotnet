using System;
using System.Collections.Generic;

namespace GenericRepoDemo
{
    // Generic Repository
    public class Repository<T>
    {
        private List<T> items = new List<T>();
        public void Add(T item)
        {
            items.Add(item);
        }
        public void Update(int index, T newItem)
        {
            if (index >= 0 && index < items.Count)
                items[index] = newItem;
        }
        public void Delete(int index)
        {
            if (index >= 0 && index < items.Count)
                items.RemoveAt(index);
        }
        public IEnumerable<T> GetAll()
        {
            foreach (var item in items)
                yield return item;  // sends one by one
        }
    }
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    class Program
    {
        static void Main()
        {
            Repository<Student> repo = new Repository<Student>();
            repo.Add(new Student { Id = 1, Name = "Hari" });
            repo.Add(new Student { Id = 2, Name = "Kumar" });
            repo.Update(1, new Student { Id = 2, Name = "Prasath" });
            repo.Delete(0);
            Console.WriteLine("Students in repository:");
            foreach (var student in repo.GetAll())
                Console.WriteLine($"{student.Id} - {student.Name}");
        }
    }
}
