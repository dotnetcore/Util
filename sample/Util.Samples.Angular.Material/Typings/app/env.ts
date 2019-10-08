/**
 * 环境变量
 */
export let env = {
    prod() {
        return process.env.NODE_ENV === "prod";
    }
};