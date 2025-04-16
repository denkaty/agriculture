interface ImportMetaEnv {
    readonly VITE_API_GATEWAY_URL: string;
    // Add other env variables here
}

interface ImportMeta {
    readonly env: ImportMetaEnv;
}
