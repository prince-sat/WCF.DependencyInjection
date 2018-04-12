using AuthBehavior.Behaviors;
using Business.Entities;
using Business.Services.Contracts;
using Data.Core.Infrastructure;
using Data.Core.Repositories;
using Exceptions.Exceptions;
using Exceptions.ExceptionsWcf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services.Implementations
{
    [AuthenticationInspectorBehavior]
    [GlobalHandlerErrorBehavior]
    public class BlogService : IBlogService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IBlogRepository _blogRepository;

        public BlogService(IUnitOfWork unitOfWork, IBlogRepository blogRepository)
        {
            _unitOfWork = unitOfWork;
            _blogRepository = blogRepository;
        }
        public void Add(Blog blog)
        {
            _blogRepository.Add(blog);
            _unitOfWork.Commit();
        }

        public void Update(Blog blog)
        {
            _blogRepository.Update(blog);
            _unitOfWork.Commit();
        }

        public void Delete(Blog blog)
        {
            _blogRepository.Delete(blog);
            _unitOfWork.Commit();
        }

        public BlogInfo GetById(BlogRequest blogRequest)
        {
            if (_blogRepository.GetById(blogRequest.BlogId) == null)
            {
                BlogInexistantException exception = new BlogInexistantException(string.Format("Blog Introuvable id : {0} ", blogRequest.BlogId));
                throw exception;

            }
            return new BlogInfo(_blogRepository.GetById(blogRequest.BlogId));
        }

        public Blog[] GetAll()
        {
            return _blogRepository.GetAll().ToArray();
        }
    }
}
