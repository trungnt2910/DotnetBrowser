// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

import { dotnet } from './dotnet.js'

const is_browser = typeof window != "undefined"
if (!is_browser) throw new Error(`Expected to be running in a browser`)
const runtime = await dotnet
    .withDiagnosticTracing(false)
    .withApplicationArgumentsFromQuery()
    .create()
const config = runtime.getConfig()
await runtime.runMainAndExit(config.mainAssemblyName, [])
