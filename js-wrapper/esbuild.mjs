#!/usr/bin/env node

import * as esbuild from 'esbuild';
import esbuildPluginTsc from 'esbuild-plugin-tsc';

await esbuild.build({
    entryPoints: [
        {out:"wrapper", in: "./src/wrapper.ts"},
        {out: "mock", in: "./src/mock.ts"}
    ],
    sourceRoot: './src',
    bundle: true,
    platform: 'browser',
    outdir: './dist',
    format: 'iife',
    target: ['es2020'],
    sourcemap: true,
    globalName:"wrapper",
    plugins: [esbuildPluginTsc({
        tsconfig: './tsconfig.json',
        keepNamespaces: true,
        force: true,
    })],
})