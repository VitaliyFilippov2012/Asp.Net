using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace PhoneBookLibrary
{
    public interface IContactsContext
    {
        DbSet<PhoneBooks> PhoneBooks { get; set; }

        int SaveDbChangesAsync();
    }
}
