using System.Threading.Tasks;
using Xunit;

namespace Util.Caching.EasyCaching.Tests {
    /// <summary>
    /// EasyCaching����������
    /// </summary>
    public class CacheTest {
        /// <summary>
        /// �������
        /// </summary>
        private readonly ICache _cache;

        /// <summary>
        /// ���Գ�ʼ��
        /// </summary>
        /// <param name="cache">�������</param>
        public CacheTest( ICache cache ) {
            _cache = cache;
        }

        /// <summary>
        /// ���Դӻ����л�ȡ����
        /// </summary>
        [Fact]
        public void TestGet() {
            var result = 0;
            var data = 0;
            for ( int i = 0; i < 3; i++ ) {
                result = _cache.Get( "a", () => {
                    data++;
                    return data;
                } );
            }
            Assert.Equal( 1,result );
        }

        /// <summary>
        /// ���Դӻ����л�ȡ����
        /// </summary>
        [Fact]
        public async Task TestGetAsync() {
            var result = 0;
            var data = 0;
            for ( int i = 0; i < 3; i++ ) {
                result = await _cache.GetAsync( "a",async () => {
                    data++;
                    return await Task.FromResult( data );
                } );
            }
            Assert.Equal( 1, result );
        }

        /// <summary>
        /// ������ӻ���
        /// </summary>
        [Fact]
        public void TestTryAdd() {
            Assert.False( _cache.Exists( "b" ) );
            _cache.TryAdd( "b", 1 );
            Assert.True( _cache.Exists( "b" ) );
        }

        /// <summary>
        /// �����Ƴ�����
        /// </summary>
        [Fact]
        public void TestRemove() {
            var result = 0;
            var data = 0;
            for ( int i = 0; i < 3; i++ ) {
                result = _cache.Get( "c", () => {
                    data++;
                    return data;
                } );
                _cache.Remove( "c" );
            }
            Assert.Equal( 3, result );
        }

        /// <summary>
        /// ������ջ���
        /// </summary>
        [Fact]
        public void TestClear() {
            var result = 0;
            var data = 0;
            for ( int i = 0; i < 3; i++ ) {
                result = _cache.Get( "d", () => {
                    data++;
                    return data;
                } );
                _cache.Clear();
            }
            Assert.Equal( 3, result );
        }
    }
}