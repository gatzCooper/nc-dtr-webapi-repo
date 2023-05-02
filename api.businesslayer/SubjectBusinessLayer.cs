using api.common.Interface;
using api.common.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace api.businesslayer
{
    public class SubjectBusinessLayer : ISubjectBusinessLayer
    {
        private readonly ISubjectDataAccess _subjectDataAccess;
        public SubjectBusinessLayer(ISubjectDataAccess subjectDataAccess)
        {
            _subjectDataAccess = subjectDataAccess;
        }
        public async Task<Subject> CreateSubjectAsync(Subject subject)
        {
            return await _subjectDataAccess.AddSubjectAsync(subject);
        }

        public void DeleteSubjectAsync(Subject subject)
        {
            _subjectDataAccess?.DeleteSubjectAsync(subject);
        }

        public async Task<Subject> GetSubjectByIdAsync(int id)
        {
            return await _subjectDataAccess.GetSubjectByIdAsync(id);
        }

        public async Task<IEnumerable<Subject>> GetSubjectsListAsync()
        {
           return await _subjectDataAccess.GetSubjectListAsync();
        }

        public async Task<Subject> UpdateSubjectAsync(Subject subject)
        {
            return await _subjectDataAccess.UpdateSubjectAsync(subject);
        }
    }
}
