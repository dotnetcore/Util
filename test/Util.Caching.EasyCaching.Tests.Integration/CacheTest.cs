using Xunit;

namespace Util.Caching.EasyCaching.Tests {
    /// <summary>
    /// EasyCachingª∫¥Ê∑˛ŒÒ≤‚ ‘
    /// </summary>
    public class CacheTest {
        /// <summary>
        /// ª∫¥Ê∑˛ŒÒ
        /// </summary>
        private readonly ICache _cache;

        /// <summary>
        /// ≤‚ ‘≥ı ºªØ
        /// </summary>
        /// <param name="cache">ª∫¥Ê∑˛ŒÒ</param>
        public CacheTest( ICache cache ) {
            _cache = cache;
        }

        /// <summary>
        /// ≤‚ ‘¥”ª∫¥Ê÷–ªÒ»° ˝æ›
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
        /// ≤‚ ‘ÃÌº”ª∫¥Ê
        /// </summary>
        [Fact]
        public void TestTryAdd() {
            Assert.False( _cache.Exists( "b" ) );
            _cache.TryAdd( "b", 1 );
            Assert.True( _cache.Exists( "b" ) );
        }

        /// <summary>
        /// ≤‚ ‘“∆≥˝ª∫¥Ê
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
        /// ≤‚ ‘«Âø’ª∫¥Ê
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