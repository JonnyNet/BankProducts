using System.Reflection;

namespace BankProducts.Domain.Enums;

public class Enumeration : IComparable
{
    public short Id { get; protected set; }
    public string Name { get; protected set; }
    public string Description { get; set; }

    protected Enumeration(short id, string name, string description) => (Id, Name, Description) = (id, name, description);

    public override string ToString() => Name;

    public static IEnumerable<T> GetAll<T>() where T : Enumeration =>
        typeof(T).GetFields(BindingFlags.Public |
                            BindingFlags.Static |
                            BindingFlags.DeclaredOnly)
                 .Select(f => f.GetValue(null))
                 .Cast<T>();

    public override bool Equals(object? obj)
    {
        if (obj is not Enumeration otherValue)
        {
            return false;
        }

        bool typeMatches = GetType().Equals(obj.GetType());
        bool valueMatches = Id.Equals(otherValue.Id);

        return typeMatches && valueMatches;
    }

    public int CompareTo(object? other)
    {
        int result = default;
        if (other != null)
        {
            result = Id.CompareTo(((Enumeration)other).Id);
        }
        return result;
    }

    protected static T? BuildItem<T>(short id) where T : Enumeration
    {
        IEnumerable<T> itemList = GetAll<T>();
        T? item = itemList.FirstOrDefault(x => x.Id == id);
        return item;
    }

    public override int GetHashCode() => Id.GetHashCode();
}