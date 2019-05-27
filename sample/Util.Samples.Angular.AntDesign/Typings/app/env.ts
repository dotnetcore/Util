/**
 * 环境变量
 */
export let env = {
    /**
     * 是否生产环境
     */
    prod() {
        return process.env.NODE_ENV === "prod";
    },
    /**
     * 是否开发环境
     */
    dev() {
        return process.env.NODE_ENV === "dev";
    }
};