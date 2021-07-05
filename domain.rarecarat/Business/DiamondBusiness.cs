
using System;
using System.Linq;
using System.Collections.Generic;
using AutoMapper;
using System.Threading.Tasks;
using core.rarecarat;
using model.rarecarat;
using data.rarecarat.Repository;
using data.rarecarat.Entities;
using domain.rarecarat.Contracts;
using FluentValidation;
using Microsoft.Extensions.Logging;

namespace domain.rarecarat.Business
{
    public class DiamondBusiness : IDiamondBusiness
    {
        private IDiamondRepository _DiamondRepository;
        private IMapper _mapper;
        private ILogger _logger;

        public DiamondBusiness( IDiamondRepository DiamondRepository, IMapper mapper, ILogger<DiamondBusiness> logger )
        {
            _DiamondRepository = DiamondRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<ValidationResult<object>> CreateAsync( DiamondCreateModel model )
        {
            try
            {
                var result = await _DiamondRepository.CreateAsync( _mapper.Map<Diamond>( model ) );
                return new ValidationResult<object>( result );
            }
            catch ( Exception ex )
            {
                _logger.LogError( ex, $"CreateAsync: {ex.Message}" );
                return ConstructorHelper
                    .ErrorValidationResult<object>();
            }
        }

        public async Task<OperationResult> DeleteAsync( object id )
        {
            try
            {
                await _DiamondRepository.DeleteAsync( id );
                return new OperationResult();
            }
            catch ( Exception ex )
            {
                _logger.LogError( ex, $"DeleteAsync: {ex.Message}" );

                return ConstructorHelper
                    .ErrorOperationResult();
            }

        }

        public async Task<OperationResult<List<DiamondListItemModel>>> GetAllAsync()
        {
            try
            {
                var result = await _DiamondRepository.GetAllAsync();
                return new OperationResult<List<DiamondListItemModel>>(
                        _mapper.ProjectTo<DiamondListItemModel>( result.AsQueryable() ).ToList() );
            }
            catch ( Exception ex )
            {
                _logger.LogError( ex, $"GetAllAsync: {ex.Message}" );

                return ConstructorHelper
                    .ErrorOperationResult<List<DiamondListItemModel>>();
            }
        }

        public async Task<OperationResult<DiamondDetailsModel>> GetDetailsModelAsync( object id )
        {
            try
            {
                var result = await _DiamondRepository.GetByIdAsync( id );
                return new OperationResult<DiamondDetailsModel>( _mapper.Map<DiamondDetailsModel>( result ) );
            }
            catch ( Exception ex )
            {
                _logger.LogError( ex, $"GetDetailsModelAsync: {ex.Message}" );

                return ConstructorHelper
                    .ErrorOperationResult<DiamondDetailsModel>();
            }
        }

        public async Task<OperationResult<DiamondUpdateModel>> GetUpdateModelAsync( object id )
        {
            var entity = await _DiamondRepository.GetByIdAsync( id );
            var details = _mapper.Map<DiamondUpdateModel>( entity );
            return new OperationResult<DiamondUpdateModel>( details );
        }

        public async Task<ValidationResult> UpdateAsync( DiamondUpdateModel model )
        {
            try
            {
                var entity = _mapper.Map<Diamond>( model );
                await _DiamondRepository.UpdateAsync( entity );
                return new ValidationResult();
            }
            catch ( Exception ex )
            {
                _logger.LogError( ex, $"UpdateAsync: {ex.Message}" );
                return ConstructorHelper.ErrorValidationResult();
            }
        }
    }
}
