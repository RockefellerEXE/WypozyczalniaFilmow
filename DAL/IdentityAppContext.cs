using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using WypozyczalniaFilmow.Models;

namespace WypozyczalniaFilmow.DAL
{
    public class IdentityAppContext : IdentityDbContext<AppUser, AppRole, int>
    {
    }
}
