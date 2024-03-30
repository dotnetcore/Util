namespace Util.Helpers;

/// <summary>
/// 文件监视器
/// </summary>
public class FileWatcher : IDisposable {
    /// <summary>
    /// 文件系统监视器
    /// </summary>
    private readonly FileSystemWatcher _watcher;
    /// <summary>
    /// 防抖间隔
    /// </summary>
    private int _debounceInterval;
    /// <summary>
    /// 文件监视事件过滤器
    /// </summary>
    private readonly FileWatcherEventFilter _fileWatcherEventFilter;

    /// <summary>
    /// 初始化文件监视器
    /// </summary>
    public FileWatcher() {
        _watcher = new FileSystemWatcher();
        _watcher.NotifyFilter = NotifyFilters.DirectoryName | NotifyFilters.FileName | NotifyFilters.LastWrite
                                | NotifyFilters.CreationTime | NotifyFilters.LastAccess
                                | NotifyFilters.Attributes | NotifyFilters.Size | NotifyFilters.Security;
        _debounceInterval = 200;
        _fileWatcherEventFilter = new FileWatcherEventFilter();
    }

    /// <summary>
    /// 设置防抖间隔,默认值: 200 毫秒
    /// </summary>
    /// <param name="interval">防抖间隔, 单位: 毫秒</param>
    public FileWatcher Debounce( int interval ) {
        _debounceInterval = interval;
        return this;
    }

    /// <summary>
    /// 设置监听目录路径
    /// </summary>
    /// <param name="path">目录绝对路径</param>
    /// <param name="includeSubdirectories">是否监听子目录,默认值: true</param>
    public FileWatcher Path( string path, bool includeSubdirectories = true ) {
        _watcher.Path = path;
        _watcher.IncludeSubdirectories = includeSubdirectories;
        return this;
    }

    /// <summary>
    /// 设置监听通知过滤
    /// </summary>
    /// <param name="notifyFilters">监听通知过滤</param>
    public FileWatcher NotifyFilter( NotifyFilters notifyFilters ) {
        _watcher.NotifyFilter = notifyFilters;
        return this;
    }

    /// <summary>
    /// 设置过滤模式
    /// </summary>
    /// <param name="filter">过滤模式,默认值: *.* ,范例: *.cshtml 可过滤cshtml文件</param>
    public FileWatcher Filter( string filter ) {
        _watcher.Filter = filter;
        return this;
    }

    /// <summary>
    /// 处理文件创建监听事件
    /// </summary>
    /// <param name="action">文件创建监听事件处理器</param>
    public FileWatcher OnCreated( Action<object, FileSystemEventArgs> action ) {
        _watcher.Created += ( source, e ) => {
            if ( _fileWatcherEventFilter.IsValid( e.FullPath, _debounceInterval ) )
                action( source, e );
        };
        return this;
    }

    /// <summary>
    /// 处理文件创建监听事件
    /// </summary>
    /// <param name="action">文件创建监听事件处理器</param>
    public FileWatcher OnCreatedAsync( Func<object, FileSystemEventArgs, Task> action ) {
        _watcher.Created += async ( source, e ) => {
            if ( _fileWatcherEventFilter.IsValid( e.FullPath, _debounceInterval ) )
                await action( source, e );
        };
        return this;
    }

    /// <summary>
    /// 处理文件变更监听事件
    /// </summary>
    /// <param name="action">文件变更监听事件处理器</param>
    public FileWatcher OnChanged( Action<object, FileSystemEventArgs> action ) {
        _watcher.Changed += ( source, e ) => {
            if ( _fileWatcherEventFilter.IsValid( e.FullPath, _debounceInterval ) )
                action( source, e );
        };
        return this;
    }

    /// <summary>
    /// 处理文件变更监听事件
    /// </summary>
    /// <param name="action">文件变更监听事件处理器</param>
    public FileWatcher OnChangedAsync( Func<object, FileSystemEventArgs, Task> action ) {
        _watcher.Changed += async ( source, e ) => {
            if ( _fileWatcherEventFilter.IsValid( e.FullPath, _debounceInterval ) )
                await action( source, e );
        };
        return this;
    }

    /// <summary>
    /// 处理文件删除监听事件
    /// </summary>
    /// <param name="action">文件删除监听事件处理器</param>
    public FileWatcher OnDeleted( Action<object, FileSystemEventArgs> action ) {
        _watcher.Deleted += ( source, e ) => {
            if ( _fileWatcherEventFilter.IsValid( e.FullPath, _debounceInterval ) )
                action( source, e );
        };
        return this;
    }

    /// <summary>
    /// 处理文件删除监听事件
    /// </summary>
    /// <param name="action">文件删除监听事件处理器</param>
    public FileWatcher OnDeletedAsync( Func<object, FileSystemEventArgs, Task> action ) {
        _watcher.Deleted += async ( source, e ) => {
            if ( _fileWatcherEventFilter.IsValid( e.FullPath, _debounceInterval ) )
                await action( source, e );
        };
        return this;
    }

    /// <summary>
    /// 处理文件重命名监听事件
    /// </summary>
    /// <param name="action">文件重命名监听事件处理器</param>
    public FileWatcher OnRenamed( Action<object, RenamedEventArgs> action ) {
        _watcher.Renamed += ( source, e ) => {
            if ( _fileWatcherEventFilter.IsValid( e.FullPath, _debounceInterval ) )
                action( source, e );
        };
        return this;
    }

    /// <summary>
    /// 处理文件重命名监听事件
    /// </summary>
    /// <param name="action">文件重命名监听事件处理器</param>
    public FileWatcher OnRenamedAsync( Func<object, RenamedEventArgs, Task> action ) {
        _watcher.Renamed += async ( source, e ) => {
            if ( _fileWatcherEventFilter.IsValid( e.FullPath, _debounceInterval ) )
                await action( source, e );
        };
        return this;
    }

    /// <summary>
    /// 处理文件错误监听事件
    /// </summary>
    /// <param name="action">文件错误监听事件处理器</param>
    public FileWatcher OnError( Action<object, ErrorEventArgs> action ) {
        _watcher.Error += ( source, e ) => {
            action( source, e );
        };
        return this;
    }

    /// <summary>
    /// 处理文件错误监听事件
    /// </summary>
    /// <param name="action">文件错误监听事件处理器</param>
    public FileWatcher OnErrorAsync( Func<object, ErrorEventArgs, Task> action ) {
        _watcher.Error += async ( source, e ) => {
            await action( source, e );
        };
        return this;
    }

    /// <summary>
    /// 处理文件监听器释放事件
    /// </summary>
    /// <param name="action">文件监听器释放事件处理器</param>
    public FileWatcher OnDisposed( Action<object, EventArgs> action ) {
        _watcher.Disposed += ( source, e ) => {
            action( source, e );
        };
        return this;
    }

    /// <summary>
    /// 处理文件监听器释放事件
    /// </summary>
    /// <param name="action">文件监听器释放事件处理器</param>
    public FileWatcher OnDisposedAsync( Func<object, EventArgs, Task> action ) {
        _watcher.Disposed += async ( source, e ) => {
            await action( source, e );
        };
        return this;
    }

    /// <summary>
    /// 启动监听
    /// </summary>
    public FileWatcher Start() {
        _watcher.EnableRaisingEvents = true;
        return this;
    }

    /// <summary>
    /// 停止监听
    /// </summary>
    public FileWatcher Stop() {
        _watcher.EnableRaisingEvents = false;
        return this;
    }

    /// <summary>
    /// 释放
    /// </summary>
    public void Dispose() {
        _watcher?.Dispose();
    }
}

/// <summary>
/// 文件监视事件过滤器
/// </summary>
internal class FileWatcherEventFilter {
    /// <summary>
    /// 最后一个文件
    /// </summary>
    private WatchFile _file;

    /// <summary>
    /// 监视事件是否有效
    /// </summary>
    /// <param name="path">文件路径</param>
    /// <param name="debounceInterval">防抖间隔</param>
    internal bool IsValid( string path, int debounceInterval ) {
        if ( _file != null && path == _file.Path && DateTime.Now - _file.Time < TimeSpan.FromMilliseconds( debounceInterval ) ) {
            _file = new WatchFile( path );
            return false;
        }
        _file = new WatchFile( path );
        return true;
    }
}

/// <summary>
/// 监视文件
/// </summary>
internal class WatchFile {
    /// <summary>
    /// 初始化监视文件
    /// </summary>
    /// <param name="path">文件路径</param>
    public WatchFile( string path ) {
        Path = path;
        Time = DateTime.Now;
    }

    /// <summary>
    /// 文件路径
    /// </summary>
    public string Path { get; }

    /// <summary>
    /// 处理时间
    /// </summary>
    public DateTime Time { get; }
}