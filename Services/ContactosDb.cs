using System;
using SQLite;
using HolaMundo.Utils;
using HolaMundo.Models;

namespace HolaMundo.Services
{
	public class ContactosDb
	{

        SQLiteAsyncConnection Database;

        public ContactosDb()
		{
		}

        async Task Init()
        {
            if (Database is not null)
                return;

            Database = new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);
            var result = await Database.CreateTableAsync<Contacto>();
        }

        public async Task<List<Contacto>> GetContactosAsync()
        {
            await Init();
            return await Database.Table<Contacto>().ToListAsync();
        }

        public async Task<List<Contacto>> GetContactosPorNombreAsync(string nombre)
        {
            await Init();
            return await Database.Table<Contacto>().Where(t => t.nombre.Equals(nombre)).ToListAsync();

            // SQL queries are also possible
            //return await Database.QueryAsync<TodoItem>("SELECT * FROM [TodoItem] WHERE [Done] = 0");
        }

        public async Task<Contacto> GetContactoPorCedulaAsync(string cedula)
        {
            await Init();
            return await Database.Table<Contacto>().Where(i => i.cedula.Equals(cedula)).FirstOrDefaultAsync();
        }

        public async Task<int> SaveContactoAsync(Contacto contacto)
        {
            await Init();
            return await Database.InsertAsync(contacto);
        }

        public async Task<int> UpdateContactoAsync(Contacto contacto)
        {
            await Init();
            return await Database.UpdateAsync(contacto);
            
        }

        public async Task<int> DeleteContactoAsync(Contacto contacto)
        {
            await Init();
            return await Database.DeleteAsync(contacto);
        }

    }
}