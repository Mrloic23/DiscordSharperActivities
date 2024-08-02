
import { DiscordSDK } from "@discord/embedded-app-sdk";
import { EventSchema } from "../node_modules/@discord/embedded-app-sdk/output/schema/events.js";
import { Mock, Wrapper } from "./types.js";

type SdkConfiguration = DiscordSDK["configuration"];

function createSDKConfig(): SdkConfiguration {
    return { disableConsoleLogOverride: false };
}

function instantiateSDK(clientID: string, config?: SdkConfiguration | undefined) {
    return new DiscordSDK(clientID, config);
}


/**
 * @param callback DotNet action to be invoked when the event is fired
 */
// async function subscribeToEvent(sdk: DiscordSDK, eventName: keyof typeof EventSchema, callback:(event: Zod.infer<(typeof EventSchema)[keyof typeof EventSchema]['payload']>['data'] | undefined) => void) {
//     await sdk.subscribe(eventName, callback);
// }

async function ready(sdk: DiscordSDK) {
    await sdk.ready();
}

function getCommands(sdk: DiscordSDK) {
    return sdk.commands;
}

window.DiscordWrapper = {
    createSDKConfig,
    instantiateSDK,
    //forced to inline because type definition is just breaking on this for no reason :/
    subscribeToEvent: async(sdk, event, callback) => await sdk.subscribe(event, callback),
    ready,
    getCommands
} satisfies Wrapper;