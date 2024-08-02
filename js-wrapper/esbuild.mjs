#!/usr/bin/env node

import * as esbuild from 'esbuild';

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
    globalName:"wrapper"
})