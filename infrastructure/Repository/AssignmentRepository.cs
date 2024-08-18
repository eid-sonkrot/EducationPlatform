using AutoMapper;
using Doamin.IRepository;
using Domain.Models;
using MongoDB.Driver;
using System.Linq.Expressions;

namespace infrastructure.Repository
{
    public class AssignmentRepository : MongoRepository<infrastructure.Models.Assignment>,IAssignmentRepository
    {
        private readonly IMapper _mapper;
        public AssignmentRepository(IMongoDatabase database, IMapper mapper) : base(database, "Assignments")
        {
            _mapper = mapper;
        }

        public Task AddAsync(Assignment entity)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Assignment>> FindAsync(Expression<Func<Assignment, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public async Task<Assignment> GetAssignmentByNameAsync(string assignmentName)
        {
            var filter = Builders<infrastructure.Models.Assignment>.Filter.Eq(a => a.AssignmentName, assignmentName);
            var AssignmentData = await _collection.Find(filter).FirstOrDefaultAsync();
            return _mapper.Map<Assignment>(AssignmentData);
        }

        public async Task UpdateAsync(Guid id, Assignment entity)
        {

            var filter = Builders<infrastructure.Models.Assignment>.Filter.Eq(a => a.Id, id.ToString());
            var update = Builders<infrastructure.Models.Assignment>.Update
                .Set(a => a.AssignmentName, entity.AssignmentName)
                .Set(a => a.Questions, entity.Questions)
                .Set(a => a.TeacherId, entity.TeacherId)
                .Set(a => a.TenantId, entity.TenantId)
                .Set(a => a.UpdatedAt, DateTime.UtcNow);

            await _collection.UpdateOneAsync(filter, update);
        }

        Task<IEnumerable<Assignment>> IRepository<Assignment>.GetAllAsync()
        {
            throw new NotImplementedException();
        }

        Task<Assignment> IRepository<Assignment>.GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
