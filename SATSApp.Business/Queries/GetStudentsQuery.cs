using MediatR;
using SATSApp.Data.Entities;

namespace SATSApp.Business.Queries
{
    public class GetStudentsQuery : IRequest<List<Student>>
    {
        //Query'nin alcağı parametreler buraya yazılacak 
    }
}

/*
    RequestQuery : IRequest<Response>
 */
