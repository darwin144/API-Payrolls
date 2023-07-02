using Client.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Client.Repository.Interface
{
	public interface IRepository<T, X>
		where T : class
	{
		Task<ResponseListVM<T>> Get();
		Task<ResponseViewModel<T>> Get(X Guid);
		Task<ResponseMessageVM> Post(T entity);
		Task<ResponseMessageVM> Put(T entity);
		Task<ResponseMessageVM> Deletes(X Guid);
		IEnumerable<Claim> ExtractClaims(string jwtToken);
	}
}
