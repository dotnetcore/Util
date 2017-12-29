using System;
using System.Threading.Tasks;

namespace Util.Applications {
    /// <summary>
    /// 增删改查服务 - Save
    /// </summary>
    public abstract partial class CrudServiceBase<TEntity, TDto, TRequest, TQueryParameter, TKey> {
        /// <summary>
        /// 创建
        /// </summary>
        /// <param name="request">请求参数</param>
        public void Create( TRequest request ) {
            if( request == null )
                throw new ArgumentNullException( nameof( request ) );
            var entity = ToEntity( request );
            if( entity == null )
                throw new ArgumentNullException( nameof( entity ) );
            Create( entity );
            request.Id = entity.Id.ToString();
        }

        /// <summary>
        /// 创建实体
        /// </summary>
        protected void Create( TEntity entity ) {
            CreateBefore( entity );
            entity.Init();
            _repository.Add( entity );
            CreateAfter( entity );
        }

        /// <summary>
        /// 创建前操作
        /// </summary>
        protected virtual void CreateBefore( TEntity entity ) {
        }

        /// <summary>
        /// 创建后操作
        /// </summary>
        protected virtual void CreateAfter( TEntity entity ) {
            AddLog( entity );
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="request">请求参数</param>
        public void Update( TRequest request ) {
            if( request == null )
                throw new ArgumentNullException( nameof( request ) );
            var entity = ToEntity( request );
            if( entity == null )
                throw new ArgumentNullException( nameof( entity ) );
            Update( entity );
        }

        /// <summary>
        /// 修改实体
        /// </summary>
        protected void Update( TEntity entity ) {
            UpdateBefore( entity );
            _repository.Update( entity );
            UpdateAfter( entity );
        }

        /// <summary>
        /// 修改前操作
        /// </summary>
        /// <param name="entity">实体</param>
        protected virtual void UpdateBefore( TEntity entity ) {
        }

        /// <summary>
        /// 修改后操作
        /// </summary>
        /// <param name="entity">实体</param>
        protected virtual void UpdateAfter( TEntity entity ) {
            AddLog( entity );
        }

        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="request">请求参数</param>
        public void Save( TRequest request ) {
            if( request == null )
                throw new ArgumentNullException( nameof( request ) );
            SaveBefore( request );
            var entity = ToEntity( request );
            if( entity == null )
                throw new ArgumentNullException( nameof( entity ) );
            if ( IsNew( request, entity ) ) {
                Create( entity );
                request.Id = entity.Id.ToString();
            }
            else
                Update( entity );
        }

        /// <summary>
        /// 保存前操作
        /// </summary>
        /// <param name="request">请求参数</param>
        protected virtual void SaveBefore( TRequest request ) {
        }

        /// <summary>
        /// 是否创建
        /// </summary>
        /// <param name="request">请求参数</param>
        /// <param name="entity">实体</param>
        protected virtual bool IsNew( TRequest request, TEntity entity ) {
            return string.IsNullOrWhiteSpace( request.Id ) || entity.Id.Equals( default( TKey ) );
        }

        /// <summary>
        /// 保存后操作
        /// </summary>
        protected virtual void SaveAfter() {
            WriteLog( $"保存{EntityDescription}成功" );
        }

        /// <summary>
        /// 提交后操作 - 该方法由工作单元拦截器调用
        /// </summary>
        public void CommitAfter() {
            SaveAfter();
        }

        /// <summary>
        /// 创建
        /// </summary>
        /// <param name="request">请求参数</param>
        public async Task CreateAsync( TRequest request ) {
            if( request == null )
                throw new ArgumentNullException( nameof( request ) );
            var entity = ToEntity( request );
            if( entity == null )
                throw new ArgumentNullException( nameof( entity ) );
            await CreateAsync( entity );
        }

        /// <summary>
        /// 创建实体
        /// </summary>
        protected async Task CreateAsync( TEntity entity ) {
            CreateBefore( entity );
            entity.Init();
            await _repository.AddAsync( entity );
            CreateAfter( entity );
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="request">请求参数</param>
        public async Task UpdateAsync( TRequest request ) {
            if( request == null )
                throw new ArgumentNullException( nameof( request ) );
            var entity = ToEntity( request );
            if( entity == null )
                throw new ArgumentNullException( nameof( entity ) );
            await UpdateAsync( entity );
        }

        /// <summary>
        /// 修改实体
        /// </summary>
        protected async Task UpdateAsync( TEntity entity ) {
            UpdateBefore( entity );
            await _repository.UpdateAsync( entity );
            UpdateAfter( entity );
        }

        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="request">请求参数</param>
        public async Task SaveAsync( TRequest request ) {
            if( request == null )
                throw new ArgumentNullException( nameof( request ) );
            SaveBefore( request );
            var entity = ToEntity( request );
            if( entity == null )
                throw new ArgumentNullException( nameof( entity ) );
            if( IsNew( request, entity ) )
                await CreateAsync( entity );
            else
                await UpdateAsync( entity );
        }
    }
}
