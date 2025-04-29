import { defineConfig, loadEnv } from 'vite';
import plugin from '@vitejs/plugin-react';

export default defineConfig(({mode}) => {
    const env = loadEnv(mode, process.cwd(), );

    return {
        plugins: [plugin()],
        server: {
            port: Number(env.VITE_PORT)
        }
    };
});