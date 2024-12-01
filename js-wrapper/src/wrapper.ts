
import { DiscordSDK, IDiscordSDK } from "@discord/embedded-app-sdk";
import { EventSchema } from "../node_modules/@discord/embedded-app-sdk/output/schema/events.js";
import { Mock, Wrapper } from "./types.js";

import {OAuthScopes} from "../node_modules/@discord/embedded-app-sdk/output/schema/types";
type SdkConfiguration = DiscordSDK["configuration"];

function createSDKConfig(): SdkConfiguration {
    return { disableConsoleLogOverride: false };
}

function instantiateSDK(clientID: string, config?: SdkConfiguration | undefined) {
    return new DiscordSDK(clientID, config) as unknown as IDiscordSDK; //types overlap but TS is still not happy :/
}


/**
 * @param callback DotNet action to be invoked when the event is fired
 */
// async function subscribeToEvent(sdk: DiscordSDK, eventName: keyof typeof EventSchema, callback:(event: Zod.infer<(typeof EventSchema)[keyof typeof EventSchema]['payload']>['data'] | undefined) => void) {
//     await sdk.subscribe(eventName, callback);
// }

async function ready(sdk: IDiscordSDK) {
    await sdk.ready();
}

function getCommands(sdk: IDiscordSDK) {
    return sdk.commands;
}

const subscribeToEvent = async (
    sdk: IDiscordSDK,
    event: keyof typeof EventSchema,
    callback: (event: Zod.infer<(typeof EventSchema)[keyof typeof EventSchema]['payload']>['data']) => undefined
) => await sdk.subscribe(event, callback);
function authenticate(commands : DiscordSDK["commands"], token : string) {
    return commands.authenticate({access_token: token});
}
//    Authorize(JSObject commands, string clientID, string[] scopes, string? codeChallenge, string responseType = "code", string prompt = "none", string promptChallengeMethod = "S256");

function authorize(commands : DiscordSDK["commands"], client_id : string, scope : OAuthScopes[],response_type?: 'code' | 'token', code_challenge?: string, code_challenge_method?: 'S256' | 'plain') {
    return commands.authorize({
        client_id,
        scope,
    })
}

window.DiscordWrapper = {
    createSDKConfig,
    instantiateSDK,
    //forced to inline because type definition is just breaking on this for no reason :/
    subscribeToEvent,
    ready,
    getCommands
} satisfies Wrapper;

export { createSDKConfig, instantiateSDK, ready, getCommands, subscribeToEvent };