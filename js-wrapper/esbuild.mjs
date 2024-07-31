#!/usr/bin/env node

import * as esbuild from 'esbuild';

await esbuild.build({
    entryPoints: ["./out/wrapper.js"],
    bundle: true,
    platform: 'browser',
    outfile: './dist/wrapper.mjs',
    format: 'iife',
    target: ['es2020'],
    sourcemap: true,
    globalName:"wrapper"
})