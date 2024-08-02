import { DiscordSDK, DiscordSDKMock } from "@discord/embedded-app-sdk";
import { SdkConfiguration } from "@discord/embedded-app-sdk/output/interface";
import { EventNames, EventPayloads, Mock } from "./types";
import { EventSchema } from "@discord/embedded-app-sdk/output/schema/events";
var guildID: string | null = null;
var channelID: string | null = null;

function setGuildID(id: string) {
    guildID = id;
}

function setChannelID(id: string) {
    channelID = id;
}

function createSDKConfig(): SdkConfiguration {
    return { disableConsoleLogOverride: false };
}

function instantiateSDK(clientID: string, config?: SdkConfiguration | undefined) {
    return new DiscordSDKMock(clientID, guildID, channelID);
}

async function subscribeToEvent(sdk: DiscordSDKMock,
    eventName: keyof typeof EventSchema,
    callback: (event: Zod.infer<(typeof EventSchema)[keyof typeof EventSchema]['payload']>['data'] | undefined) => void
): Promise<void> {
    await sdk.subscribe(eventName, callback);
}

async function ready(sdk: DiscordSDK) {
    await sdk.ready();
}

function getCommands(sdk: DiscordSDK) {
    return sdk.commands;
}

function emitEvent<T extends EventNames>(sdk: DiscordSDKMock, eventName: T, eventData: EventPayloads<T>) {
    sdk.emitEvent(eventName, eventData);
}

function emitReady(sdk: DiscordSDKMock) {
    sdk.emitReady();
}

window.DiscordWrapper = {
    setGuildID,
    setChannelID,
    emitEvent,
    emitReady,
    createSDKConfig,
    instantiateSDK,
    //forced to inline because type definition is just breaking on this for no reason :/
    subscribeToEvent: async(sdk, event, callback) => await sdk.subscribe(event, callback),
    ready,
    getCommands
} satisfies Mock;